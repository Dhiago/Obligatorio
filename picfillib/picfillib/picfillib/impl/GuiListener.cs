using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using PicfilLib;


namespace PicfilLib
{
    public class GuiListener: IGuiListener, IPicturePersistListener, IFilterPersistListener
    {
        private readonly IPicfilGui gui;

        private readonly IPictureRenderer renderer;

        private readonly IPictureProvider provider;

        private readonly IDictionary<String, IFilter> filters = new Dictionary<String, IFilter>();

        private IPicture currentPicture;

        //private FilterMacro currentMacro;
        
        public GuiListener(IPicfilGui gui, IPictureRenderer renderer, IPictureProvider provider, IPicture emptyPic)
        {            
            this.gui = gui;
            this.renderer = renderer;
            this.provider = provider;
            this.filters = new Dictionary<String, IFilter>();
            this.currentPicture = emptyPic;
        }

        #region IGuiListener Members

        public void AddFilter(String filterName, IFilter filter)
        {
            Debug.Assert(!this.filters.ContainsKey(filterName));
            this.filters.Add(filterName, filter);
        }
        public void ApplyFilter(String filterName)
        {
            if (IsPictureSelected())
            {
                IFilter filter = filters[filterName];
                if (filter != null)
                {
                    ApplyAndRenderFilter(filter);
                    //AddFilterToMacro(filter);
                }                
            }
        }

        public void SelectPicture(String pictureName)
        {
            SelectAndRenderPicture(pictureName);
        }

        #endregion     

        #region IMacroListener Members

        

        

        #endregion

        #region IFilterPersistListener Members

        public void PersistFilters(string fileName)
        {
            
        }

        #endregion

        private void SelectAndRenderPicture(String pictureName)
        {
            provider.ReadIntoImage(pictureName, currentPicture);
            renderer.Render(currentPicture);            
        }

        private void ApplyAndRenderFilter(IFilter filter)
        {
            currentPicture = filter.Filter(currentPicture);
            renderer.Render(currentPicture);            
        }

        

        

     

        private Boolean IsPictureSelected() 
        {
            return currentPicture != null && currentPicture.Width > 0 && currentPicture.Height > 0;
        }

        #region IPicturePersistListener Members

        public void PersistPicture(string fileName)
        {
            if (currentPicture != null)
            {
                new PictureToFilePersister().Persist(currentPicture, fileName);
            }
        }

        #endregion        
    }


}
