﻿namespace AvansDevOps;

public interface IObserver
{
    void Update(BacklogItem subject);
}