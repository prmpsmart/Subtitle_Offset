import 'dart:io';

String NEW_LINE = '\n';
String DATE_FORMAT = '1111-11-11 ';

String time2String(DateTime time) {
  return 'time.';
}

class Index {
  String? index, _text;
  DateTime? start, end;

  Index(List<String> index_lines) {
    index = index_lines[0];

    var start_end = index_lines[1].replaceAll(' ', '').split('-->');
    var start = start_end[0];
    var end = start_end[1];

    this.start = DateTime.parse(DATE_FORMAT + start);
    this.end = DateTime.parse(DATE_FORMAT + end);

    _text = index_lines.sublist(2, index_lines.length).join(NEW_LINE);
  }

  void add_offset(int offset) {
    start = start?.add(Duration(seconds: offset));
    end = end?.add(Duration(seconds: offset));
  }
  

  @override
  String toString() {
    String start = this.start.toString().replaceAll(DATE_FORMAT, '');
    String end = this.end.toString().replaceAll(DATE_FORMAT, '');

    var start_last_index = start.lastIndexOf('.');
    var end_last_index = end.lastIndexOf('.');

    start = start.replaceRange(start_last_index, start_last_index + 1, ',');
    end = end.replaceRange(end_last_index, end_last_index + 1, ',');

    return '$index$NEW_LINE$start --> $end$NEW_LINE$_text${NEW_LINE * 2}';
  }
}

class Subtitle {
  List<Index> indices = [];
  Subtitle({String file = ''}) {
    if (file.isNotEmpty) read(file);
  }

  void read(String file) {
    indices = [];
    String text = File(file).readAsStringSync();
    List<String> lines = text.split(NEW_LINE) + [NEW_LINE];

    List<String> index_lines = [];
    lines.forEach(
      (line) {
        line = line.trim();
        if (line.isNotEmpty)
          index_lines.add(line);
        else {
          if (index_lines.isNotEmpty) indices.add(Index(index_lines));
          index_lines.clear();
        }
      },
    );
  }

  void add_offset(int offset) {
    indices.forEach((index) => index.add_offset(offset));
  }

  void write(String file) {
    String text = '';
    indices.forEach((index) => text += '$index');
    var file_obj = File(file).openWrite();
    file_obj.write(text);
    file_obj.close();
  }
}

void add_offset(String file, int offset, String out) {
  var subtitle = Subtitle(file: file);
  subtitle.add_offset(offset);
  subtitle.write(out);
}

void main(List<String> args) {
  add_offset("../res/sample.srt", 10, "../res/result.srt");
}
