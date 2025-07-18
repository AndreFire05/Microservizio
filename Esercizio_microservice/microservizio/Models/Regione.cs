﻿using System;
using System.Collections.Generic;

namespace microservizio.Models;

public partial class Regione
{
    public int Id { get; set; }

    public string Denominazione { get; set; } = null!;

    public int IdRipartizione { get; set; }

    public virtual RipartizioneGeografica IdRipartizioneNavigation { get; set; } = null!;

    public virtual ICollection<Provincium> Provincia { get; set; } = new List<Provincium>();
}
