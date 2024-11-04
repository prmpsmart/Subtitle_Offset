from PySide6.QtWidgets import *
from PySide6.QtGui import *
from PySide6.QtCore import *

from s_o import Subtitle
from os import path

MULTIPLIER = 3


class Thread(QThread):
    def __init__(self, parent: "Subtitle_Offset", args):
        super().__init__(parent)

        self.func = parent.action
        self.args = args
        self.start()

    def run(self):
        self.func(*self.args)


class Subtitle_Offset(QWidget):
    progress_signal = Signal(int)

    def __init__(self, app: "Subtitle_Offset_App") -> None:
        super().__init__(f=Qt.WindowStaysOnTopHint)
        self.app = app
        self.setWindowTitle(self.__class__.__name__)
        self.setMinimumSize(300, 400)

        self.files = [str(a) for a in range(12)]
        self.files = []
        self.subtitle = Subtitle()

        layout = QVBoxLayout(self)

        hlay = QHBoxLayout()
        layout.addLayout(hlay)

        flay = QFormLayout()
        hlay.addLayout(flay)

        self._time = QTime(0, 0, 0, 0)

        self.time = QTimeEdit()
        self.time.setMinimumWidth(80)
        self.time.setDisplayFormat("HH : mm : ss")
        flay.addRow("Offset : ", self.time)

        hlay.addSpacerItem(
            QSpacerItem(
                100,
                0,
                QSizePolicy.Policy.Expanding,
                QSizePolicy.Policy.Minimum,
            )
        )

        self.negative = QCheckBox("Negative")
        hlay.addWidget(self.negative)

        self.subtitles = QListWidget()

        self.subtitles.addItems(self.files)

        self.subtitles.setSelectionMode(QListWidget.SelectionMode.MultiSelection)
        layout.addWidget(self.subtitles)

        hlay2 = QHBoxLayout()
        layout.addLayout(hlay2)

        add_subtitles = QPushButton("Add Subtitles")
        add_subtitles.clicked.connect(self.add_subtitles)
        hlay2.addWidget(add_subtitles)

        remove_subtitles = QPushButton("Remove Subtitles")
        remove_subtitles.clicked.connect(self.remove_subtitles)
        hlay2.addWidget(remove_subtitles)

        hlay3 = QHBoxLayout()
        layout.addLayout(hlay3)

        self.output = QLineEdit(
            # r"C:/Users/Administrator/Videos/K-Drama/Our Beloved Summer/Subtitles/offset_37s"
        )
        self.output.setPlaceholderText("Output Folder")

        self.output.addAction(
            QIcon("../res/folder.png"),
            QLineEdit.ActionPosition.TrailingPosition,
        ).triggered.connect(self.browse_folder)

        hlay3.addWidget(self.output)

        self._add_offset = QPushButton("Add Offset")
        self._add_offset.clicked.connect(self.add_offset)
        layout.addWidget(self._add_offset)

        self.progress = QProgressBar()
        layout.addWidget(self.progress)
        self.progress_signal.connect(self.progress.setValue)

    def add_subtitles(self):
        files = QFileDialog.getOpenFileNames(
            self,
            "Subtitles",
            # r"C:\Users\Administrator\Videos\K-Drama\Our Beloved Summer\Subtitles",
            '',
            "Subtitle files (*.srt *.txt)",
        )[0]

        for file in files:
            if file not in self.files:
                self.subtitles.addItem(file)
                self.files.append(file)

    def remove_subtitles(self):
        selections = self.subtitles.selectedIndexes()
        if selections:
            count = 0
            selection: QModelIndex = None
            for selection in selections:
                row = selection.row()
                self.subtitles.takeItem(row - count)
                del self.files[row]
                count += 1
        else:
            self.subtitles.clear()
            self.files.clear()

    def browse_folder(self):
        folder = QFileDialog.getExistingDirectory(self, "Subtitles Output Folder")
        self.output.setText(folder)

    def add_offset(self):
        offset = self._time.secsTo(self.time.time())
        if offset:
            if self.negative.isChecked():
                offset *= -1
            output = self.output.text()
            if output:
                selected_subtitles = self.subtitles.selectedItems()

                if selected_subtitles:
                    answer = QMessageBox.question(
                        self,
                        "Selected only",
                        "Set offset for only selected subtitle files?",
                    )
                    if answer == QMessageBox.StandardButton.Yes:
                        subtitles = [sub.text() for sub in selected_subtitles]
                    else:
                        subtitles = self.files
                else:
                    subtitles = self.files

                self._add_offset.setDisabled(True)

                self.progress.setMaximum(len(subtitles))

                Thread(self, [subtitles, output, offset])

            else:
                QMessageBox.critical(
                    self, "Choose Output Folder", "Output folder must be chosen first!"
                )
        else:
            QMessageBox.critical(self, "Set Offset", "Offset must be chosen first!")

    def action(self, subtitles, output, offset):
        for index, sub in enumerate(subtitles):
            basename = path.basename(sub)
            name, ext = path.join(output, path.splitext(basename))

            self.subtitle.read(sub)
            self.subtitle.add_offset(offset)
            self.subtitle.write(f"{name}-offset_{offset}-seconds{ext}")

            self.progress_signal.emit(index + 1)

        self._add_offset.setEnabled(True)

    def closeEvent(self, event: QCloseEvent) -> None:
        self.app.quit()


class Subtitle_Offset_App(QApplication):
    def __init__(self):
        super().__init__()

        self.window = Subtitle_Offset(self)
        self.window.show()

        self.exec()


Subtitle_Offset_App()
