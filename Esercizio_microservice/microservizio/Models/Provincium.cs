﻿using System;
using System.Collections.Generic;

namespace microservizio.Models;

public partial class Provincium
{
    public int Id { get; set; }

    public string Denominazione { get; set; } = null!;

    public string Sigla { get; set; } = null!;

    public int? CodiceCittaMetropolitana { get; set; }

    public int IdRegione { get; set; }

    public virtual ICollection<Comune> Comunes { get; set; } = new List<Comune>();

    public virtual Regione IdRegioneNavigation { get; set; } = null!;
}
