﻿using NameThatTuneBot.MusicHandler.Parser;
using NameThatTuneBot.MusicHandler.Parser.Interfaces;

namespace NameThatTubeBotTest.MusicHandler.FakeObjects
{
    public class MockMusicWebClient:IMusicWebClient
    {
        public  string Response { get; set; }
        public string GetResponse(AddressITunesConstructor address)
        {
            return Response;
        }
    }
}