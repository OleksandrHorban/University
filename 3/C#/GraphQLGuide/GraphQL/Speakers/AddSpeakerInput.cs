﻿namespace GraphQL.Speakers
{
    public record AddSpeakerInput(
        string Name,
        string? Bio,
        string? WebSite);
}
