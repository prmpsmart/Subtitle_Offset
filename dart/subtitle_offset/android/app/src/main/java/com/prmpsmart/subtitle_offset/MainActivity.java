package com.prmpsmart.subtitle_offset;

import io.flutter.embedding.android.FlutterActivity;
import io.flutter.embedding.engine.FlutterEngine;

public class MainActivity extends FlutterActivity {
    private static final String CHANNEL = "Subtitle_Offset";
    Subtitle subtitle = new Subtitle();

    @Override
    public void configureFlutterEngine(@NonNull FlutterEngine flutterEngine) {
        
        GeneratedPluginRegistrant.registerWith(flutterEngine);
        System.out.println("JAVA " + CHANNEL + " REGISTERED ");
        new MethodChannel(flutterEngine.getDartExecutor().getBinaryMessenger(), CHANNEL)
        .setMethodCallHandler(
                (call, result) -> {
                    switch (call.method) {
                        case "select_subtitles": {
                            break;
                        }
                        case "select_output_folder": {
                            break;
                        }
                        case "subtitles": {
                            break;
                        }
                    }
                }
        );
    }
}
