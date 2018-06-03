using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextModel {
    public int textIndex;
    public int spriteIndex;
    public int voiceIndex;

    public bool isMusicSection = false;

    public TextModel (int textIndex, int voiceIndex, int spriteIndex) {
        this.textIndex = textIndex;
        this.spriteIndex = spriteIndex;
        this.voiceIndex = voiceIndex;
    }

    public TextModel (bool isMusicSection, int spriteIndex) {
        this.isMusicSection = true;
        this.spriteIndex = spriteIndex;
    }

    public override string ToString () {
        return textIndex.ToString() + ", " + spriteIndex.ToString() + ", " + voiceIndex.ToString() + ", " + isMusicSection.ToString();
    }
}

public interface StorageInterface {
    List<AudioClip> voices { get; }
    List<Sprite> sprites { get; }
    List<string> texts { get; }
    List<TextModel> models { get; }

    string chapterCompleteString { get; }
}

public class LyricModel {
    public int lyricIndex;
    public float startTime;

    public LyricModel(int lyricIndex, float startTime) {
        this.lyricIndex = lyricIndex;
        this.startTime = startTime;
    }
}

public interface LyricStorageInterface {
    List<string> lyrics { get; }
    List<LyricModel> lyricModels { get; }
    float endTime { get; }

}
