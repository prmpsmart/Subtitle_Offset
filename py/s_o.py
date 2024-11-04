from datetime import datetime, timedelta

TIME_FORMAT = "%H:%M:%S,%f"
NEW_LINE = "\n"


class Time:
    def __init__(self, string):
        self.datetime = datetime.strptime(string, TIME_FORMAT)

    def addSecs(self, seconds):
        self.datetime += timedelta(seconds=seconds)

    def __str__(self) -> str:
        time = self.datetime.strftime(TIME_FORMAT)
        res = time.rstrip("0")
        if len(res) < 12:
            res += "0" * (12 - len(res))
        return res


class Index:
    def __init__(self, index_lines):
        self.index = index_lines[0]
        start, end = index_lines[1].replace(" ", "").split("-->")
        self.start = Time(start)
        self.end = Time(end)
        self._text = "\n".join(index_lines[2:])

    def add_offset(self, seconds: int):
        self.start.addSecs(seconds)
        self.end.addSecs(seconds)

    def __str__(self) -> str:
        return f"{self.index}{NEW_LINE}{self.start} --> {self.end}{NEW_LINE}{self._text}{NEW_LINE*2}"


class Subtitle:

    def __init__(self, file: str = "") -> None:
        self.indices: list[Index] = []

        if file:
            self.read(file)

    def read(self, file):
        self.indices.clear()

        file_obj = open(file)
        text = file_obj.read()
        lines = text.split(NEW_LINE) + [NEW_LINE]

        index_lines = []
        for line in lines:
            line = line.strip()
            if line:
                index_lines.append(line)
            else:
                if index_lines:
                    self.indices.append(Index(index_lines))
                index_lines.clear()

    def add_offset(self, offset: int):
        for index in self.indices:
            index.add_offset(offset)

    def write(self, file):
        text = ""
        for index in self.indices:
            text += str(index)

        file_obj = open(file, "w")
        file_obj.write(text)
        file_obj.close()


def add_offset(file: str, offset: int, out: str):
    subtitle = Subtitle(file)
    subtitle.add_offset(offset)
    subtitle.write(out)
