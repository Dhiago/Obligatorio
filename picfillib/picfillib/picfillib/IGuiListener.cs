using System;
using System.Collections.Generic;
using System.Text;

namespace PicfilLib
{
    public interface IGuiListener
    {
        /// <summary>
        /// Agrega un filtro a la lista de filtros del listener
        /// No se puede agregar un filtro que ya existe en la lista con el mismo nombre
        /// </summary>
        /// <param name="filterName">Nombre del filtro</param>
        /// <param name="filter">IFilter a agregar a la lista bajo el nombre dado</param>
        void AddFilter(String filterName, IFilter filter);
        /// <summary>
        /// Aplica un filtro.
        /// </summary>
        /// <remarks>
        /// <para>
        /// La accion a tomar depende de la implementacion.
        /// </para>
        /// <para>
        /// Para el ejercicio 3, se debe aplicar el filtro sobre la ultima imagen seleccionada. Si no
        /// hay ninguna imagen seleccionada, no se debe aplicar el filtro.
        /// </para>        
        /// </remarks>
        /// <param name="pictureName">el nombre del filtro</param>
        void ApplyFilter (String filterName);

        /// <summary>
        /// Seleccionar una imagen.
        /// </summary>
        /// <remarks>
        /// <para>
        /// La accion a tomar depende de la implementacion. Si el nombre de la imagen es invalido
        /// o no refiere a ninguna imagen existente, se debe lanzar una excepcion de tipo
        /// <code>ArgumentException</code> especificando el mensaje de error.
        /// </para>
        /// <para>
        /// Para el ejercicio 3, se debe mostrar la imagen en la interfaz de usuario.
        /// </para>        
        /// </remarks>
        /// <param name="pictureName">el nombre de la imagen, puede o no ser valido</param>        
        void SelectPicture (String pictureName);        
    }
}
