// ignore_for_file: prefer_const_constructors, sized_box_for_whitespace, non_constant_identifier_names, prefer_const_literals_to_create_immutables

import 'dart:async';
import 'dart:io';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';

String NEW_LINE = '\n';
String DATE_FORMAT = '1111-11-11 ';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      // debugShowCheckedModeBanner: false,
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: MyHomePage(title: 'Subtitle_Offset'),
    );
  }
}

class MyHomePage extends StatefulWidget {
  final subtitle = Subtitle();
  static MethodChannel platform = const MethodChannel('Subtitle_Offset');

  static void add_offset(String file, int offset, String out) {}

  MyHomePage({Key? key, required this.title}) : super(key: key);

  final String title;

  @override
  State<MyHomePage> createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  bool value = false;
  List<String> subtitles = [];
  List<String> selected_subtitles = [];

  @override
  void initState() {
    for (int i = 0; i < 20; i++) {
      subtitles.add(i.toString());
    }
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.title),
      ),
      body: Column(
        children: [
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Row(
                  children: [
                    Text(
                      'Offset : ',
                      style: TextStyle(
                        fontSize: 15,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                    SpinBox(),
                  ],
                ),
                CheckText('Negative'),
              ],
            ),
          ),
          Expanded(
            child: ListView.builder(
              padding: const EdgeInsets.only(bottom: 10),
              itemCount: subtitles.length,
              itemBuilder: (BuildContext context, int index) =>
                  CheckText('Negative ' + subtitles[index]),
            ),
          ),
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                iconNButton(
                  'Add Subtitles',
                  Icons.shopping_cart_outlined,
                  func: () {},
                ),
                iconNButton(
                  'Remove Subtitles',
                  Icons.remove_shopping_cart_outlined,
                  func: () {},
                ),
              ],
            ),
          ),
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: iconNButton(
              'Output Folder',
              Icons.folder_outlined,
              func: () {},
            ),
          ),
          Padding(
            padding: const EdgeInsets.only(bottom: 20, left: 20, right: 20),
            child: LinearProgressIndicator(
              value: 1,
              minHeight: 20,
              color: Colors.green,
              backgroundColor: Colors.blue,
            ),
          ),
        ],
      ),
    );
  }
}

// ignore: must_be_immutable
class CheckText extends StatefulWidget {
  String text;
  double size;
  Function()? func;
  CheckText(this.text, {Key? key, this.size = 15, this.func}) : super(key: key);

  @override
  _CheckTextState createState() => _CheckTextState();
}

class _CheckTextState extends State<CheckText> {
  bool value = false;
  @override
  Widget build(BuildContext context) {
    return MaterialButton(
      padding: EdgeInsets.all(2),
      onPressed: () => setState(() {
        value = !value;
        if (widget.func != null) widget.func!();
      }),
      child: Row(
        children: [
          Checkbox(
            value: value,
            onChanged: (value) {
              setState(() {
                this.value = value ?? false;
                if (widget.func != null) widget.func!();
              });
            },
          ),
          Text(
            widget.text,
            style: TextStyle(
              fontSize: widget.size,
            ),
          ),
        ],
      ),
    );
  }
}

Container iconNButton(String text, IconData icon, {Function? func}) {
  return Container(
    height: 30,
    child: ElevatedButton(
      onPressed: () {
        if (func != null) func();
      },
      child: Row(
        children: [
          Icon(icon, size: 18),
          Padding(
            padding: const EdgeInsets.only(left: 10),
            child: Text(
              text,
              style: TextStyle(
                fontSize: 15,
                fontWeight: FontWeight.w400,
              ),
            ),
          ),
        ],
      ),
    ),
  );
}

class SpinBox extends StatefulWidget {
  const SpinBox({Key? key}) : super(key: key);

  @override
  _SpinBoxState createState() => _SpinBoxState();
}

class _SpinBoxState extends State<SpinBox> {
  late TextEditingController controller;
  int value = 0;

  bool increaseTimer = false;
  bool decreaseTimer = false;

  @override
  void initState() {
    controller = TextEditingController();
    controller.text = value.toString();
    super.initState();
  }

  @override
  void setState(VoidCallback fn) {
    controller.text = value.toString();
    super.setState(fn);
  }

  void increase() {
    value += 1;
    setState(() {});
  }

  void decrease() {
    value -= 1;
    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisSize: MainAxisSize.min,
      children: [
        SizedBox(
          width: 60,
          height: 50,
          child: TextField(
            onEditingComplete: () {
              value = double.parse(controller.text).toInt();
            },
            onChanged: (value) {
              this.value = double.parse(value).toInt();
            },
            onSubmitted: (value) {
              this.value = double.parse(value).toInt();
            },
            controller: controller,
            keyboardType: TextInputType.number,
          ),
        ),
        Column(
          mainAxisSize: MainAxisSize.min,
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            InkResponse(
              onLongPress: () {
                increaseTimer = true;
                Timer.periodic(
                  Duration(milliseconds: 200),
                  (timer) {
                    if (!increaseTimer) {
                      timer.cancel();
                    } else {
                      increase();
                    }
                  },
                );
              },
              onTap: () {
                increaseTimer = false;
                increase();
              },
              child: Icon(
                Icons.arrow_drop_up_outlined,
                size: 40,
                color: Theme.of(context).primaryColor,
              ),
            ),
            InkResponse(
              onLongPress: () {
                decreaseTimer = true;
                Timer.periodic(
                  Duration(milliseconds: 200),
                  (timer) {
                    if (!decreaseTimer) {
                      timer.cancel();
                    } else {
                      decrease();
                    }
                  },
                );
              },
              onTap: () {
                decreaseTimer = false;
                decrease();
              },
              child: Icon(
                Icons.arrow_drop_down_outlined,
                size: 40,
                color: Theme.of(context).primaryColor,
              ),
            ),
          ],
        ),
      ],
    );
  }
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

  void read(String file) {
    indices = [];
    String text = File(file).readAsStringSync();
    List<String> lines = text.split(NEW_LINE) + [NEW_LINE];

    List<String> index_lines = [];
    for (var line in lines) {
      line = line.trim();
      if (line.isNotEmpty) {
        index_lines.add(line);
      } else {
        if (index_lines.isNotEmpty) indices.add(Index(index_lines));
        index_lines.clear();
      }
    }
  }

  void add_offset(int offset) {
    for (var index in indices) {
      index.add_offset(offset);
    }
  }

  void write(String file) {
    String text = '';
    for (var index in indices) {
      text += '$index';
    }
    var file_obj = File(file).openWrite();
    file_obj.write(text);
    file_obj.close();
  }
}
