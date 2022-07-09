using AccesoData.Entidades;
using AccesoData.Repositorios;
using Dominio.ObjetoValor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class CategoriaModel
    {
        private int pk_categoria;
        private string cateCodigo;
        private string cateNombre;
        private int cateEstado;

        //Encapsulando propiedades
        public int Pk_categoria { get => pk_categoria; set => pk_categoria = value; }
        [Required]
        public string CateCodigo { get => cateCodigo; set => cateCodigo = value; }
        [Required]
        public string CateNombre { get => cateNombre; set => cateNombre = value; }
        public int CateEstado { get => cateEstado; set => cateEstado = value; }

        private CategoriaRepositorio categoriaRepositorio;
        public EstadoEntidad estado { get; set; }

        public CategoriaModel()
        {
            categoriaRepositorio = new CategoriaRepositorio();
        }

        public string GuardarCambios()
        {
            string mensaje = string.Empty;
            try
            {
                var cateDataModel = new Categoria();
                cateDataModel.pk_categoria = pk_categoria;
                cateDataModel.cateCodigo = cateCodigo;
                cateDataModel.cateNombre = cateNombre;
                cateDataModel.cateEstado = cateEstado;

                switch (estado)
                {
                    case EstadoEntidad.insertar:
                        categoriaRepositorio.insertar(cateDataModel);
                        break;
                    case EstadoEntidad.modificar:
                        categoriaRepositorio.modificar(cateDataModel);
                        break;
                    case EstadoEntidad.eliminar:
                        categoriaRepositorio.eliminar(pk_categoria);
                        break;
                }
            }
            catch(Exception ex)
            {
                SqlException sqlException = ex as SqlException;
                if(sqlException != null && sqlException.Number == 2627)
                {
                    mensaje = "La categoria ya existe";
                }
            }

            return mensaje;
        }

        public DataView listarCategoria()
        {
            DataView dv = categoriaRepositorio.listar();

            return dv;
        }

        public void actualizarEstado(int pk,int estado,string nameTable)
        {
            categoriaRepositorio.actualizarEstado(pk, estado, nameTable);
        }

        public List<CategoriaModel> GetAll()
        {
            var categoriaDataModel = categoriaRepositorio.GetAll();
            var listaCategoria = new List<CategoriaModel>();
            foreach (Categoria item in categoriaDataModel)
            {
                listaCategoria.Add(new CategoriaModel
                {
                    pk_categoria = item.pk_categoria,
                    cateNombre = item.cateNombre
                });
            }
            return listaCategoria;
        }

        public IEnumerable<CategoriaModel> seleccionarCategoria(int pk_categoria)
        {
            var categoriaDataModel = categoriaRepositorio.seleccionarCategoria(pk_categoria);
            var listaCategoria = new List<CategoriaModel>();
            foreach(var item in categoriaDataModel)
            {
                listaCategoria.Add(new CategoriaModel
                {
                    pk_categoria = item.pk_categoria,
                    cateCodigo = item.cateCodigo,
                    cateNombre = item.cateNombre
                });
            }
            return listaCategoria;
        }
    }
}
