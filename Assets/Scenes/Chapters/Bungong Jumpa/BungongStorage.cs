using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BungongStorage : MonoBehaviour, StorageInterface {

	public List<Sprite> sprites { get { return _sprites; } }
    public List<AudioClip> voices { get { return _voices; } }
    public List<string> texts { get { return _texts; } }
    public List<TextModel> models { get { return _models; } }

    public string chapterCompleteString {
        get {
            return "Hore! kamu telah menyelesaikan cerita Bungong Jeumpa. Ikuti terus perjalanan seru bersama Pangeran Nusa.";
        }
    }

    public List<Sprite> _sprites;
    public List<AudioClip> _voices;
    public List<string> _texts = new List<string>(new string[] {
        "Setelah menempuh perjalanan yang cukup jauh, akhirnya pangeran tiba di daerah paling barat, yaitu Aceh.",
        "Kemudian ia menanyakan pendapat dari kepala desa tentang benda terindah di daerah ini.",
        "\"Ah.. Bunga Cempaka saja.\", jawab kepala desa.",
        "Pangeran yang belum pernah melihat bunga yang konon sangat indah itu pun menjadi penasaran dan meminta kepala desa untuk memperlihatkannya.",
		"Pangeran sampai di sebuah hutan dan melihat sebuah pohon bunga cempaka yang sangat indah.",
		"Pangeran hanya bisa berdecak kagum menyaksikan keindahan bunga-bunga cempaka itu.",
		"\"Ah! Aku menemukannya, hadiah terindah untuk ulangtahun ayahanda! Mmm.. Boleh aku membawanya ke kerajaan?\"",
		"\"Tentu saja yang mulia. Namun jika saya boleh berpendapat, lebih baik yang mulia membawakan raja sesuatu yang lain. Hmm! Misalkan lagu.\"",
		"\"Lagu? Kenapa demikian?\" pangeran heran.",
		"\"Mereka sama-sama indah, namun bunga pada akhirnya akan layu, tidak seperti lagu yang akan terus bermekaran di hati yang mendengarkan.\"",
		"\"Wah, lagu Bungong Jeumpa, termyata lagu tentang bunga cempaka. Sungguh indah bagaikan bunganya.\"",
		"\"Hmm, maukah kamu menyanyikan lagu Bungong Jeumpa pada raja di hari ulang tahunnya?\"",
		"\"Tentu saja. Berarti sekarang saya ikut yang mulia ke istana?\" kata kepala desa.",
		"\"Tidak, aku masih harus berkelana.\"",
		"\"Sudah kuputuskan bahwa hadiah yang akan kuberi adalah keindahan alunan lagu daerah yang ada di kerajaan Nusantara.\"",
		"Kemudian pangeran pun melanjutkan perjalanannya."
    });
    public List<TextModel> _models = new List<TextModel>(new TextModel[] {
		new TextModel(0,0,0),
        new TextModel(1,1,0),
        new TextModel(2,2,0),
        new TextModel(3,3,0),
        new TextModel(4,4,1),
        new TextModel(5,5,1),
        new TextModel(6,6,1),
        new TextModel(7,7,2),
        new TextModel(8,8,2),
        new TextModel(9,9,2),
        new TextModel(10,10,3),
        new TextModel(11,11,3),
        new TextModel(12,12,3),
        new TextModel(13,13,3),
        new TextModel(14,14,4),
        new TextModel(15,15,4),
    });
}
