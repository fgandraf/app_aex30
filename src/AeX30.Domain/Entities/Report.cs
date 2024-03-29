﻿using System;

namespace AeX30.Domain.Entities
{
    public class Report
    {
        public Report(Request referencia, Proposal proposal, string mensuradoAcumulado, string contratoInicio, string contratoTermino)
        {
            this.Request = referencia;
            this.Proposal = proposal;
            MensuradoAcumulado = mensuradoAcumulado;
            ContratoInicio = contratoInicio;
            ContratoTermino = contratoTermino;
        }

        public dynamic[] Get()
        {
            dynamic[] values = { 
                Request.Reference[1], 
                Request.Reference[2], 
                Convert.ToInt32(Request.Reference[3]),
                Request.Reference[4], 
                Request.Reference[5], 
                Request.Reference[6], 
                Proposal.ProponenteNome, 
                Proposal.ProponenteCPF.Number, 
                Proposal.ProponenteDDD, 
                Proposal.ProponenteFone.Number, 
                Proposal.ResponsavelNome, 
                Proposal.ResponsavelCauCrea, 
                Proposal.ResponsavelUF, 
                Proposal.ResponsavelCPF.Number, 
                Proposal.ResponsavelDDD, 
                Proposal.ResponsavelFone.Number, 
                Proposal.ImovelEndereco, 
                Proposal.ImovelComplemento, 
                Proposal.ImovelBairro, 
                Proposal.ImovelCep.Number, 
                Proposal.ImovelMunicipio, 
                Proposal.ImovelUF, 
                Proposal.ImovelValorTerreno.Number, 
                Proposal.ImovelMatricula, 
                Proposal.ImovelOficio, 
                Proposal.ImovelComarca, 
                Proposal.ImovelComarcaUF, 
                Convert.ToDouble(Proposal.ServicoItem01),
                Convert.ToDouble(Proposal.ServicoItem02),
                Convert.ToDouble(Proposal.ServicoItem03),
                Convert.ToDouble(Proposal.ServicoItem04),
                Convert.ToDouble(Proposal.ServicoItem05),
                Convert.ToDouble(Proposal.ServicoItem06),
                Convert.ToDouble(Proposal.ServicoItem07),
                Convert.ToDouble(Proposal.ServicoItem08),
                Convert.ToDouble(Proposal.ServicoItem09),
                Convert.ToDouble(Proposal.ServicoItem10),
                Convert.ToDouble(Proposal.ServicoItem11),
                Convert.ToDouble(Proposal.ServicoItem12),
                Convert.ToDouble(Proposal.ServicoItem13),
                Convert.ToDouble(Proposal.ServicoItem14),
                Convert.ToDouble(Proposal.ServicoItem15),
                Convert.ToDouble(Proposal.ServicoItem16),
                Convert.ToDouble(Proposal.ServicoItem17),
                Convert.ToDouble(Proposal.ServicoItem18),
                Convert.ToDouble(Proposal.ServicoItem19),
                Convert.ToDouble(Proposal.ServicoItem20),
                MensuradoAcumulado == "" ? 0.00 : MensuradoAcumulado, 
                ContratoInicio == "  /  /" ? "" : Convert.ToDateTime(ContratoInicio),
                ContratoTermino == "  /  /" ? "" : Convert.ToDateTime(ContratoTermino),
                Convert.ToDouble(Proposal.CronogramaExecutado),
                Convert.ToDouble(Proposal.CronogramaEtapa1),
                Convert.ToDouble(Proposal.CronogramaEtapa2),
                Convert.ToDouble(Proposal.CronogramaEtapa3),
                Convert.ToDouble(Proposal.CronogramaEtapa4),
                Convert.ToDouble(Proposal.CronogramaEtapa5),
                Convert.ToDouble(Proposal.CronogramaEtapa6),
                Convert.ToDouble(Proposal.CronogramaEtapa7),
                Convert.ToDouble(Proposal.CronogramaEtapa8),
                Convert.ToDouble(Proposal.CronogramaEtapa9),
                Convert.ToDouble(Proposal.CronogramaEtapa10),
                Convert.ToDouble(Proposal.CronogramaEtapa11),
                Convert.ToDouble(Proposal.CronogramaEtapa12),
                Convert.ToDouble(Proposal.CronogramaEtapa13),
                Convert.ToDouble(Proposal.CronogramaEtapa14),
                Convert.ToDouble(Proposal.CronogramaEtapa15),
                Convert.ToDouble(Proposal.CronogramaEtapa16),
                Convert.ToDouble(Proposal.CronogramaEtapa17),
                Convert.ToDouble(Proposal.CronogramaEtapa18),
                Convert.ToDouble(Proposal.CronogramaEtapa19),
                Convert.ToDouble(Proposal.CronogramaEtapa20),
                Convert.ToDouble(Proposal.CronogramaEtapa21),
                Convert.ToDouble(Proposal.CronogramaEtapa22),
                Convert.ToDouble(Proposal.CronogramaEtapa23),
                Convert.ToDouble(Proposal.CronogramaEtapa24),
                Convert.ToDouble(Proposal.CronogramaEtapa25),
                Convert.ToDouble(Proposal.CronogramaEtapa26),
                Convert.ToDouble(Proposal.CronogramaEtapa27),
                Convert.ToDouble(Proposal.CronogramaEtapa28),
                Convert.ToDouble(Proposal.CronogramaEtapa29),
                Convert.ToDouble(Proposal.CronogramaEtapa30)
            };

            return values;
        }

        public Request Request { get; private set; }
        public Proposal Proposal { get; private set; }
        public string MensuradoAcumulado { get; private set; }
        public string ContratoInicio { get; private set; }
        public string ContratoTermino { get; private set; }
    }
}