package Subtitle_Offset.src;

import java.time.LocalTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;

public class Index {
    static public String NEW_LINE = "\n";

    String index = "", _text = "", DELIM = "-->";

    DateTimeFormatter TIME_FORMAT = DateTimeFormatter.ofPattern("HH:mm:ss,SSS");

    LocalTime start, end;

    static ArrayList<String> numbers = new ArrayList<String>() {
        {
            add("1");
            add("2");
            add("3");
            add("4");
            add("5");
            add("6");
            add("7");
            add("8");
            add("9");
            add("0");
        }
    };

    public Index(ArrayList<String> index_lines) {
        String index = index_lines.get(0);
        for (int i = 0; i < index.length(); i++) {
            char letter = index.charAt(i);

            if (numbers.contains(String.valueOf(letter)))
                this.index += letter;
        }

        String[] start_end = index_lines.get(1).split(DELIM);

        start = LocalTime.parse(start_end[0].replace(" ", ""), TIME_FORMAT);
        end = LocalTime.parse(start_end[1].replace(" ", ""), TIME_FORMAT);

        for (int line = 2; line < index_lines.size(); line++)
            _text += index_lines.get(line) + NEW_LINE;
    }

    public void add_offset(int offset) {
        start = start.plusSeconds(offset);
        end = end.plusSeconds(offset);
    }

    @Override
    public String toString() {
        String text = index + NEW_LINE + start.format(TIME_FORMAT) + " " + DELIM + " "
                + end.format(TIME_FORMAT)
                + NEW_LINE + _text + NEW_LINE;
        return text;
    }
}
