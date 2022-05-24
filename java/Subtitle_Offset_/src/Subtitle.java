package Subtitle_Offset.src;

import java.io.FileWriter;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;

class Subtitle {
    ArrayList<Index> indices = new ArrayList<Index>();

    public boolean read(String file) {
        indices.clear();

        try {
            List<String> lines = Files.readAllLines(Paths.get(file));
            lines.add(" ");

            ArrayList<String> index_lines = new ArrayList<String>();
            for (String line_ : lines) {
                String line = line_.trim();
                if (!line.isEmpty())
                    index_lines.add(line);
                else {
                    if (index_lines.size() > 0)
                        indices.add(new Index(index_lines));
                    index_lines.clear();
                }
            }

            return true;
        }

        catch (IOException e) {
            System.out.println("Something went wrong " + e.toString());
            return false;
        }
    }

    public void add_offset(int offset) {
        for (Index index : indices)
            index.add_offset(offset);
    }

    public void write(String file) {
        String text = "";
        for (Index index : indices)
            text += index.toString();

        try {
            FileWriter file_obj = new FileWriter(file);
            file_obj.write(text);
            file_obj.close();
        } catch (IOException e) {
            System.out.println("Error occurred in writing");
        }
    }

}