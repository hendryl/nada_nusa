using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITantanganAnswer {
    int id { get; }
    string answer { get; }
    Sprite buttonImage { get; }
}

public interface ITantanganQuestion {
    AudioClip voice { get; }
    TantanganAnswer answer { get; }
}

public interface ITantanganQuiz {
    List<TantanganAnswer> choices { get; }
}

public interface ITantanganStorage {

    void Setup();
    TantanganQuiz GetNextQuiz();
}

public class TantanganAnswer {
    public int id { get { return _id; } }
    public string answer { get { return _answer; } }
    public Sprite buttonImage { get { return _buttonImage; } }

    int _id;
    string _answer;
    Sprite _buttonImage;

    public TantanganAnswer (int i, string a, Sprite b) {
        _id = i;
        _answer = a;
        _buttonImage = b;
    }
}

public class TantanganQuestion {
    public AudioClip voice { get { return _voice; } }
    public TantanganAnswer answer { get { return _answer; } }

    AudioClip _voice;
    TantanganAnswer _answer;

    public TantanganQuestion (AudioClip v, TantanganAnswer a) {
        _voice = v;
        _answer = a;
    }
}

public class TantanganQuiz : ITantanganQuiz {
    public TantanganQuestion question { get { return _question; } }
    public List<TantanganAnswer> choices { get { return _choices; } }

    TantanganQuestion _question;
    List<TantanganAnswer> _choices;

    public TantanganQuiz (TantanganQuestion q, List<TantanganAnswer> c) {
        _question = q;
        _choices = c;
    }
}


public class TantanganStorage : MonoBehaviour, ITantanganStorage {
    public List<AudioClip> clips;
    public List<string> answers;
    public List<Sprite> buttonImages;

    List<TantanganQuiz> quiz;
    int currentQuiz = 0;

    List<TantanganQuestion> possibleQuestions;
    List<TantanganAnswer> possibleAnswers;
    System.Random rand;

    public void Setup () {
        rand = new System.Random();
        possibleQuestions = new List<TantanganQuestion>();
        possibleAnswers = new List<TantanganAnswer>();

        for (int i = 0; i < clips.Count; i++) {
            TantanganAnswer answer = new TantanganAnswer(i, answers[i], buttonImages[i]);
            TantanganQuestion question = new TantanganQuestion(clips[i], answer);
            possibleQuestions.Add(question);
            possibleAnswers.Add(answer);
        }

        MakeQuiz();
    }

    void MakeQuiz () {
        int count = possibleQuestions.Count;
        int[] order = new int[count];

        for (int i = 0; i < count; i++) {
            order[i] = i;
        }

        // shuffle the order
        order = Shuffle(order);

        // create quiz
        quiz = new List<TantanganQuiz>();

        for (int i = 0; i < count; i++) {
            TantanganQuestion q = possibleQuestions[order[i]];
            TantanganAnswer answer = q.answer;

            // this logic is still wronggg
            int wrongOneId = 0;
            int wrongTwoId = 0;

            do {
                wrongOneId = rand.Next(0, count);
            } while(answer.id == wrongOneId);

            do {
                wrongTwoId = rand.Next(0, count);
            } while(answer.id == wrongTwoId || wrongOneId == wrongTwoId);

            TantanganAnswer wrongOne = possibleAnswers.Find(x => x.id == wrongOneId);
            TantanganAnswer wrongTwo = possibleAnswers.Find(x => x.id == wrongTwoId);

            TantanganAnswer[] answerArray = Shuffle<TantanganAnswer>(
                new TantanganAnswer[] {
                    answer,
                    wrongOne,
                    wrongTwo
                }
            );

            List<TantanganAnswer> answerList = new List<TantanganAnswer>(answerArray);
            quiz.Add(new TantanganQuiz(q, answerList));
        }
    }

    T[] Shuffle<T> (T[] arr, int times = 1000) {
        for (int i = 0; i < times; i++) {
            int x = rand.Next(0, arr.Length);
            int y = rand.Next(0, arr.Length);

            T temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }

        return arr;
    }

    public TantanganQuiz GetNextQuiz () {
        TantanganQuiz result = quiz[currentQuiz];

        if (currentQuiz + 1 > quiz.Count - 1) {
            currentQuiz = 0;
            MakeQuiz();
        } else {
            currentQuiz += 1;
        }

        return result;
    }
}