using Ftec.ProjetosWeb.RedeSocial.Aplicacao.DTO;
using Ftec.ProjetosWeb.RedeSocial.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.RedeSocial.Aplicacao.Adapter
{
    public static class CurtidasAdapter
    {
        public static List<CurtidaDTO> ParaDTO(List<Curtida> curtidas)
        {
            List<CurtidaDTO> curtidas1 = new List<CurtidaDTO>();

            foreach (Curtida curtida in curtidas)
            {
                curtidas1.Add(ParaDTO(curtida));
            }

            return curtidas1;
        }
        public static List<Curtida> ParaDomain(List<CurtidaDTO> curtidas)
        {
            List<Curtida> curtidas1 = new List<Curtida>();

            foreach (CurtidaDTO curtida in curtidas)
            {
                curtidas1.Add(ParaDomain(curtida));
            }

            return curtidas1;
        }
        public static Curtida ParaDomain(CurtidaDTO curtida)
        {
            return new Curtida()
            {
                Id = curtida.Id,
                IdUsuario = curtida.IdUsuario,
                DataCurtida = curtida.DataCurtida,
                Reacao = (Dominio.Entidades.TipoReacao)curtida.Reacao,
                IdPostPai = curtida.IdPostPai,
            };
        }
        public static CurtidaDTO ParaDTO(Curtida curtida)
        {
            return new CurtidaDTO()
            {
                Id = curtida.Id,
                IdUsuario = curtida.IdUsuario,
                DataCurtida = curtida.DataCurtida,
                Reacao = (DTO.TipoReacao)(Dominio.Entidades.TipoReacao)curtida.Reacao,
                IdPostPai = curtida.IdPostPai,
            };
        }
    }
}
