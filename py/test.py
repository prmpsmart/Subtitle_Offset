import os
from s_o import add_offset

subtitles_folder = r"C:\Users\USER\Videos\KDrama\The Judge from Hell\hi-engcp"

assert os.path.isdir(subtitles_folder)

parent_folder = os.path.dirname(subtitles_folder)
basename = os.path.basename(subtitles_folder)

results_folder = os.path.join(parent_folder, f"{basename}-offsets")
os.makedirs(results_folder, exist_ok=True)

files = [
    os.path.join(subtitles_folder, file)
    for file in os.listdir(subtitles_folder)
    if os.path.splitext(file)[-1].lower() in [".txt", ".srt"]
]

for file in files:
    basename = os.path.basename(file)
    result_file = os.path.join(results_folder, basename)

    add_offset(file, -3, result_file)