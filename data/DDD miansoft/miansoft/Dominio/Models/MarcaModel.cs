using AccesoData.Contratos;
using AccesoData.Entidades;
using AccesoData.Repositorios;
using Dominio.ObjetoValor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Dominio.Models
{
    public class MarcaModel
    {
        private int pk_marca;
        private string marcCodigo;
        private string marcNombre;
        private int marcEstado;

        private IMarcaRepositorio marcaRepositorio;
        public EstadoEntidad estado { private get; set; }
        //Encapsulamiento
        public int Pk_marca { get => pk_marca; set => pk_marca = value; }
        [Required]
        public string MarcCodigo { get => marcCodigo; set => marcCodigo = value; }
        [Required]
        public string MarcNombre { get => marcNombre; set => marcNombre = value; }
        public int MarcEstado { get => marcEstado; set => marcEstado = value; }

    

        //Constructor
        public MarcaModel()
        {
            marcaRepositorio = new MarcaRepositorio();
        }

        public string GuardarCambios()
        {
            string mensaje = null;
            try
            {
                var marcaDataModel = new Marca();
                marcaDataModel.pk_marca = pk_marca;
                marcaDataModel.marcCodigo = marcCodigo;
                marcaDataModel.marcNombre = marcNombre;
                marcaDataModel.marcEstado = marcEstado;

                switch (estado)
                {
                    case EstadoEntidad.insertar:
                        marcaRepositorio.insertar(marcaDataModel);
                        mensaje = "Se inserto correctamente";
                        break;
                    case EstadoEntidad.modificar:
                        marcaRepositorio.modificar(marcaDataModel);
                        mensaje = "Se modifico correctamente";
                        break;
                    case EstadoEntidad.eliminar:
                        marcaRepositorio.eliminar(pk_marca);
                        mensaje = "Se elimino correctamente";
                        break;
                }

            }catch(Exception ex)
            {
                SqlException sqlException = ex as SqlException;
                if (sqlException != null && sqlException.Number == 2627)
                {
                    mensaje = "Ya existe la marca en la base de datos";
                }
            }


            return mensaje;
        }

        public DataView listar()
        {
            DataView dv = marcaRepositorio.listar();

            return dv;
        }

        public void actualizarEstado(int pk,int estado, string tabla)
        {
            marcaRepositorio.actualizarEstado(pk, estado, tabla);
        }

        public List<MarcaModel> GetAll()
        {
            var marcaDataModel = marcaRepositorio.GetAll();
            var listaMarca = new List<MarcaModel>();
            foreach (Marca item in marcaDataModel)
            {
                listaMarca.Add(new MarcaModel
                {
                    pk_marca = item.pk_marca,
                    marcNombre = item.marcNombre
                });
            }
            return listaMarca;
        }

        public IEnumerable<MarcaModel> seleccionaMarca(int pk_marca)
        {
            var marcaDataModel = marcaRepositorio.seleccionarMarca(pk_marca);
            var listaMarca = new List<MarcaModel>();
            foreach(var item in marcaDataModel)
            {
                listaMarca.Add(new MarcaModel
                {
                    pk_marca = item.pk_marca,
                    marcCodigo = item.marcCodigo,
                    marcNombre = item.marcNombre
                });
            }

            return listaMarca;
        }
    }
}
