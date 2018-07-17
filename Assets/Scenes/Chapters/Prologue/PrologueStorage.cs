using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrologueStorage : MonoBehaviour, StorageInterface {

    public List<Sprite> sprites { get { return _sprites; } }
    public List<AudioClip> voices { get { return _voices; } }
    public List<string> texts { get { return _texts; } }
    public List<TextModel> models { get { return _models; } }

    public string chapterCompleteString {
        get {
            return "Ikuti terus perjalanan pangeran Nusa mencari hadiah terindah untuk ulang tahun ayahanda.";
        }
    }

    public List<Sprite> _sprites;
    public List<AudioClip> _voices;
    public List<string> _texts = new List<string>(new string[] {
        "Di sebuah kerajaan besar yang terbagi menjadi berbagai daerah bernama \"Nusantara\", hiduplah Raja Antara dan Ratu Nadaswara.",
        "Raja dan Ratu memiliki seorang anak yang bernama Pangeran Mada Nusa.",
        "Setiap hari, sang raja selalu mengajarkan Pangeran Nusa bagaimana menjadi seorang raja yang baik agar kelak dapat menggantikan tahtanya menjadi Raja Nusantara.",
        "Suatu ketika sang raja menasihati Pangeran Nusa.",
        "\"Anakku Pangeran Nusa, menjadi seorang raja adalah memahami keindahan dari yang dipimpinnya.\"",
        "Ingin membalas budi semua ilmu yang diberikan ayahnya, Pangeran Nusa ingin mencarikan sang raja hadiah yang paling indah untuk hari ulang tahunnya.",
        "Sang pangeran pun memutuskan untuk berkelana ke daerah-daerah di Kerajaan Nusantara.",
        "Ia mempersiapkan segala hal yang dibutuhkan dalam perjalanan dari makanan, pakaian, hingga obat-obatan.",
        "Ia juga membawa pergi pusaka ajaibnya yaitu “Peta Keinginan” yang dapat menunjukkan lokasi keinginan pemiliknya.",
        "Kemudian pangeran berpamitan dengan raja dan ratu lalu berangkat mencari hadiah untuk ayahnya.",
        "Pangeran membuka peta ajaib miliknya. Namun karena ia belum mengetahui hadiah apa yang ingin diberikan kepada raja, peta belum menunjukkan daerah yang ingin dituju.",
        "\"Waduh, petanya masih kosong, kalau begitu aku akan coba cari hadiah raja dari daerah yang paling barat.\"",
        "Pangeran pun memulai perjalanan mencari hadiah.",
        "Prolog"
    });
    public List<TextModel> _models = new List<TextModel>(new TextModel[] {
        new TextModel(13, -1, 7),
        new TextModel(0,0,0),
        new TextModel(1,1,0),
        new TextModel(2,2,1),
        new TextModel(3,3,1),
        new TextModel(4,4,1),
        new TextModel(5,5,2),
        new TextModel(6,6,3),
        new TextModel(7,7,4),
        new TextModel(8,8,4),
        new TextModel(9,9,5),
        new TextModel(10,10,5),
        new TextModel(11,11,6),
        new TextModel(12,12,6),
    });
}
