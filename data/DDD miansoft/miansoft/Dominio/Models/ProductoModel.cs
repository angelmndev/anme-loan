using AccesoData.Contratos;
using AccesoData.Entidades;
using AccesoData.Repositorios;
using Dominio.ObjetoValor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class ProductoModel
    {
        public int pk_producto { get; set; }
        public string prodDescripcion {get;set;}
        public string prodCodigo {get;set;}
        public double prodPrecioUnitario {get;set;}
        public string prodFoto {get;set;}
        public double prodStkMin {get;set;}
        public double prodStkMax {get;set;}
        public int fk_categoria {get;set;}
        public int fk_presentacion {get;set;}
        public int fk_unidadMedida {get;set;}
        public int fk_marca {get;set;}
        public int prodEstado {get;set;}
        public int prodPerecedero { get; set; }

        //private List<ProductoModel> listaProducto;=>remplazamos con datatable
        private IProductoRepositorio productoRepositorio;
        public EstadoEntidad estado {private get; set; }

        //Constructor
        public ProductoModel()
        {
            productoRepositorio = new ProductoRepositorio();
        }

        public string guardarCambios()
        {
            string mensaje = string.Empty;
            try
            {
                var productoModel = new Producto();
                productoModel.pk_producto = pk_producto;
                productoModel.prodDescripcion = prodDescripcion;
                productoModel.prodCodigo = prodCodigo;
                productoModel.prodPrecioUnitario = prodPrecioUnitario;
                productoModel.prodFoto = prodFoto;
                productoModel.prodStkMin = prodStkMin;
                productoModel.prodStkMax = prodStkMax;
                productoModel.fk_categoria = fk_categoria;
                productoModel.fk_presentacion = fk_presentacion;
                productoModel.fk_unidadMedida = fk_unidadMedida;
                productoModel.fk_marca = fk_marca;
                productoModel.prodEstado = prodEstado;
                productoModel.prodPerecedero = prodPerecedero;

                switch (estado)
                {
                    case EstadoEntidad.insertar:
                        productoRepositorio.insertar(productoModel);
                        break;
                    case EstadoEntidad.modificar:
                        productoRepositorio.modificar(productoModel);
                        break;
                    case EstadoEntidad.eliminar:
                        productoRepositorio.eliminar(pk_producto);
                        break;
                }

            }
            catch(Exception ex)
            {
                SqlException sql = ex as SqlException;
                if (sql != null && sql.Number == 2627)
                {
                    mensaje = "EL codigo del producto ya existe";
                }
            }

            return mensaje;
        }

        public DataView listar()
        {
            DataView dv = productoRepositorio.listar();        
            return dv;
        }

        public IEnumerable<ProductoModel> seleccionarProducto(int pk)
        {
            var productoDataModel = productoRepositorio.seleccionarProducto(pk);
            List<ProductoModel> listaProducto = new List<ProductoModel>();
            foreach (Producto item in productoDataModel)
            {
                listaProducto.Add(new ProductoModel
                {
                    pk_producto = item.pk_producto,
                    prodDescripcion = item.prodDescripcion,
                    prodCodigo = item.prodCodigo,
                    prodPrecioUnitario = item.prodPrecioUnitario,
                    prodFoto = item.prodFoto,
                    prodStkMin = item.prodStkMin,
                    prodStkMax = item.prodStkMax,
                    fk_categoria = item.fk_categoria,
                    fk_presentacion = item.fk_presentacion,
                    fk_unidadMedida = item.fk_unidadMedida,
                    fk_marca = item.fk_marca,
                    prodEstado = item.prodEstado,
                    prodPerecedero = item.prodPerecedero

                });
            }
            return listaProducto;
        }

        public void modificarPrecioVenta(int pk,double prodPrecioUnitario)
        {
            productoRepositorio.modificarPrecioVenta(pk, prodPrecioUnitario);
        }
    }
}
