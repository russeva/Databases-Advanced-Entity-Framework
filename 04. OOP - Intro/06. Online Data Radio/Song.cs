using System;
using System.Collections.Generic;
using System.Text;

class Song
{
    private string artistname;
    private string songname;
    private DateTime duration;

    public Song(string artistname, string songname, DateTime duration)
    {
        this.Artistname = artistname;
        this.Songname = songname;
        this.Duration = duration;
    }

    public string Artistname
    {
        get => this.artistname;
        private set
        {
            if(value.Length < 2 || value.Length > 19)
            {
                
            }
              this.artistname = value;

        }
    }
    public string Songname
    {
        get => this.songname;
        private set
        {
            if(value.Length < 2 || value.Length > 19)
            {

            }
            this.songname = value;
        }
    }
    public DateTime Duration
    {
        get => this.duration;
        private set
        {
            if(value.)
            this.duration = value;
        }
    }
}

