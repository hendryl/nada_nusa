using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmparStorage : MonoBehaviour, StorageInterface, LyricStorageInterface {

	public List<Sprite> sprites { get { return _sprites; } }
    public List<AudioClip> voices { get { return _voices; } }
    public List<string> texts { get { return _texts; } }
    public List<TextModel> models { get { return _models; } }

    public List<string> lyrics { get { return _lyrics; } }

    public List<LyricModel> lyricModels { get { return _lyricModels; }}

    public float endTime { get { return _endTime; }}

    public string chapterCompleteString {
        get {
            return "Hore! kamu telah menyelesaikan cerita Ampar Ampar Pisang. Ikuti terus perjalanan seru bersama Pangeran Nusa.";
        }
    }

    public List<Sprite> _sprites;
    public List<AudioClip> _voices;
    List<string> _texts = new List<string>(new string[] {
        "Sesampainya di daerah berikutnya yaitu Kalimantan Selatan, Pangeran mencium aroma manis dari sebuah desa.",
        "\"Wah aroma enak apa ini? Aku belum pernah mencium aroma semanis ini.\" ujarnya.",
        "Penasaran, sang pangeran berkunjung ke desa tersebut.",
        "Di desa, pangeran bertemu dengan sebuah keluarga dan ia terkejut melihat tumpukan buah pisang yang banyak sekali.",
		"\"Wah banyak sekali pisangnya. Apa yang sedang kalian lakukan?\" tanya pangeran.",
		"\"Ah, Iya.. Kami sedang mengupas pisang-pisang ini untuk dijadikan kue rimpi.\" jawab ibu sambil menjejerkan pisang.",
		"\"Kue rimpi yang enak itu? Wah menarik sekali. Boleh aku ikut membuatnya?\" tanya pangeran.",
		"\"Tentu saja boleh, ayo ikut aku!\" ajak seorang anak laki-laki.",
		"\"Akhirnya selesai juga! Hmm… Enak sekali rasanya\" ujar pangeran Nusa sembari mencicipi kue rimpi.",
		"\"Terima kasih semuanya, karena telah mengajarkan aku cara membuat kue rimpi, benar-benar pengalaman yang menyenangkan.\" ujar pangeran.",
		"Semuanya pun merasa senang mendengar ucapan pangeran.",
		"\"Oh iya, lagu apa yang kalian nyanyikan tadi? Baru pertama kali aku dengar lagu yang begitu bersemangat.\" tanya pangeran Nusa.",
		"\"Lagu itu berjudul Ampar-Ampar Pisang. Lagu yang kami nyanyikan saat membuat kue rimpi.\" jawab bapak.",
		"\"Oooooh… Luar Biasa.\" ujar pangeran.",
		"\"Bagaimana jika kalian aku undang ke pesta ulang tahun raja untuk menyanyikan lagu Ampar-ampar Pisang?\" lanjutnya.",
		"Bapak, ibu, kakak, dan adik sangat senang dan menerima undangan tersebut. "
    });
    List<TextModel> _models = new List<TextModel>(new TextModel[] {
		new TextModel(0,0,0),
        new TextModel(1,1,0),
        new TextModel(2,2,0),
        new TextModel(3,3,1),
        new TextModel(4,4,1),
        new TextModel(5,5,1),
        new TextModel(6,6,2),
        new TextModel(7,7,2),
		new TextModel(true, 2),
        new TextModel(8,8,3),
        new TextModel(9,9,3),
        new TextModel(10,10,3),
        new TextModel(11,11,4),
        new TextModel(12,12,4),
        new TextModel(13,13,5),
        new TextModel(14,14,5),
        new TextModel(15,15,5),
    });

    List<string> _lyrics = new List<string>(new string[] {
        "Ampar ampar pisang",
        "Pisangku balum masak",
        "Masak bigi di hurung bari-bari",
        "Manggalepak manggalepok, Patah kayu bengkok",
        "Bengkok dimakan api apinya can curupan",
        "Nang mana batis kutung Dikitipi dawang",
        "..."
    });

    List<LyricModel> _lyricModels = new List<LyricModel>(new LyricModel[] {
        new LyricModel(6, 0),
        new LyricModel(0, 7),
        new LyricModel(1, 10),
        new LyricModel(2, 12),
        new LyricModel(3, 20),
        new LyricModel(4, 24),
        new LyricModel(5, 32),

		new LyricModel(0, 39),
        new LyricModel(1, 40.8f),
        new LyricModel(2, 43),
        new LyricModel(3, 51),
        new LyricModel(4, 55),
        new LyricModel(5, 62),
        new LyricModel(6, 71),

        new LyricModel(0, 78),
        new LyricModel(1, 80),
        new LyricModel(2, 82),
        new LyricModel(3, 89),
        new LyricModel(4, 94),
        new LyricModel(5, 101),

		new LyricModel(0, 108),
        new LyricModel(1, 111),
        new LyricModel(2, 113),
        new LyricModel(3, 121),
        new LyricModel(4, 125),
        new LyricModel(5, 132),
        new LyricModel(6, 137),
    });

    float _endTime = 138f;
}
