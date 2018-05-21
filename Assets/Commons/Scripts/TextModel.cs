using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextModel {
    public int textIndex;
    public int spriteIndex;
    public int voiceIndex;

    public TextModel (int textIndex, int voiceIndex, int spriteIndex) {
        this.textIndex = textIndex;
        this.spriteIndex = spriteIndex;
        this.voiceIndex = voiceIndex;
    }
}

public interface StorageInterface {
    List<AudioClip> voices { get; }
    List<Sprite> sprites { get; }
    List<string> texts { get; }
    List<TextModel> models { get; }
}
