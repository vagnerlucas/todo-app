﻿using System;
using TodoApp.Domain.ValueObjects;

namespace TodoApp.Domain.Task
{
    public class Task
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DoneAt { get; set; }
        public bool Done { get; set; }
    }
}