using System;
using System.Collections;
using System.Collections.Generic;
class NoteBook
{
    public class Note
    {
        private string fullName;
        private DateTime birthDate;
        private string phoneNumber;

        public string FullName
        {
            get
            {
                return this.fullName;
            }
            set
            {
                this.fullName = value;
            }
        }
        public DateTime BirthDate
        {
            get
            {
                return this.birthDate;
            }
            set
            {
                this.birthDate = value;
            }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public Note(string fullName, DateTime birthDate, string phoneNumber)
        {
            this.fullName = fullName;
            this.birthDate = birthDate;
            this.phoneNumber = phoneNumber;
        }

        public static int CompareByName(Note x, Note y)
        {
            return x.fullName.CompareTo(y.fullName);
        }
    }

    private List<Note> notes = new List<Note>();

    public Note SearchByName(string fullName)
    {
        foreach (Note note in this.notes)
        {
            if (note.FullName == fullName) return note;
        }
        return null;
    }
    public Note SearchByDate(DateTime birthDate)
    {
        foreach (Note note in this.notes)
        {
            if (note.BirthDate == birthDate) return note;
        }
        return null;
    }
    public Note SearchByPhone(string phoneNumber)
    {
        foreach (Note note in this.notes)
        {
            if (note.PhoneNumber == phoneNumber) return note;
        }
        return null;
    }
    public void RemoveNote(Note note)
    {
        this.notes.Remove(note);
    }

    public void AddNote(Note note)
    {
        this.notes.Add(note);
    }

    public void Sort()
    {
        this.notes.Sort(Note.CompareByName);
    }

    public void SortManual()
    {
        for (int i = 0; i < notes.Count - 1; i++)
        {
            Note min = notes[i];
            int minIndex = i;

            for (int j = i + 1; j < notes.Count; j++)
            {
                if (Note.CompareByName(notes[j], min) < 0)
                {
                    min = notes[j];
                    minIndex = j;
                }
            }

            notes[minIndex] = notes[i];
            notes[i] = min;
        }
    }
    public Note this[int i]
    {
        get { return this.notes[i]; }

        set { this.notes[i] = value; }
    }

    public int Count
    {
        get { return this.notes.Count; }
    }

}