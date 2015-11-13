﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Dominio.Repositorio
{
    public interface ILocacaoRepositorio
    {
        Locacao BuscarPorId(int id);
        Locacao BuscarJogoLivre(int idJogo);
        int Criar(Locacao locacao);
        int Atualizar(Locacao locacao);
        int BuscarIdPorIdJogo(int id);
    }
}
