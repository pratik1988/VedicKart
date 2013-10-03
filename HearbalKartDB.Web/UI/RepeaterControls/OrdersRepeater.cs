using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.Design.WebControls;
using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace HearbalKartDB.Web.UI
{
    /// <summary>
    /// A designer class for a strongly typed repeater <c>OrdersRepeater</c>
    /// </summary>
	public class OrdersRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:OrdersRepeaterDesigner"/> class.
        /// </summary>
		public OrdersRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is OrdersRepeater))
			{ 
				throw new ArgumentException("Component is not a OrdersRepeater."); 
			} 
			base.Initialize(component); 
			base.SetViewFlags(ViewFlags.TemplateEditing, true); 
		}


		/// <summary>
		/// Generate HTML for the designer
		/// </summary>
		/// <returns>a string of design time HTML</returns>
		public override string GetDesignTimeHtml()
		{

			// Get the instance this designer applies to
			//
			OrdersRepeater z = (OrdersRepeater)Component;
			z.DataBind();

			return base.GetDesignTimeHtml();

			//return z.RenderAtDesignTime();

			//	ControlCollection c = z.Controls;
			//Totem z = (Totem) Component;
			//Totem z = (Totem) Component;
			//return ("<div style='border: 1px gray dotted; background-color: lightgray'><b>TagStat :</b> zae |  qsdds</div>");

		}
	}

    /// <summary>
    /// A strongly typed repeater control for the <see cref="OrdersRepeater"/> Type.
    /// </summary>
	[Designer(typeof(OrdersRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:OrdersRepeater runat=\"server\"></{0}:OrdersRepeater>")]
	public class OrdersRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:OrdersRepeater"/> class.
        /// </summary>
		public OrdersRepeater()
		{
		}

		/// <summary>
        /// Gets a <see cref="T:System.Web.UI.ControlCollection"></see> object that represents the child controls for a specified server control in the UI hierarchy.
        /// </summary>
        /// <value></value>
        /// <returns>The collection of child controls for the specified server control.</returns>
		public override ControlCollection Controls
		{
			get
			{
				this.EnsureChildControls();
				return base.Controls;
			}
		}

		private ITemplate m_headerTemplate;
		/// <summary>
        /// Gets or sets the header template.
        /// </summary>
        /// <value>The header template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(OrdersItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate HeaderTemplate
		{
			get { return m_headerTemplate; }
			set { m_headerTemplate = value; }
		}

		private ITemplate m_itemTemplate;
		/// <summary>
        /// Gets or sets the item template.
        /// </summary>
        /// <value>The item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(OrdersItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate ItemTemplate
		{
			get { return m_itemTemplate; }
			set { m_itemTemplate = value; }
		}

		private ITemplate m_seperatorTemplate;
        /// <summary>
        /// Gets or sets the Seperator Template
        /// </summary>
        [Browsable(false)]
        [TemplateContainer(typeof(OrdersItem))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public ITemplate SeperatorTemplate
        {
            get { return m_seperatorTemplate; }
            set { m_seperatorTemplate = value; }
        }
			
		private ITemplate m_altenateItemTemplate;
        /// <summary>
        /// Gets or sets the alternating item template.
        /// </summary>
        /// <value>The alternating item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(OrdersItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate AlternatingItemTemplate
		{
			get { return m_altenateItemTemplate; }
			set { m_altenateItemTemplate = value; }
		}

		private ITemplate m_footerTemplate;
        /// <summary>
        /// Gets or sets the footer template.
        /// </summary>
        /// <value>The footer template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(OrdersItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate FooterTemplate
		{
			get { return m_footerTemplate; }
			set { m_footerTemplate = value; }
		}

//      /// <summary>
//      /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
//      /// </summary>
//		protected override void CreateChildControls()
//      {
//         if (ChildControlsCreated)
//         {
//            return;
//         }

//         Controls.Clear();

//         //Instantiate the Header template (if exists)
//         if (m_headerTemplate != null)
//         {
//            Control headerItem = new Control();
//            m_headerTemplate.InstantiateIn(headerItem);
//            Controls.Add(headerItem);
//         }

//         //Instantiate the Footer template (if exists)
//         if (m_footerTemplate != null)
//         {
//            Control footerItem = new Control();
//            m_footerTemplate.InstantiateIn(footerItem);
//            Controls.Add(footerItem);
//         }
//
//         ChildControlsCreated = true;
//      }
	
		/// <summary>
        /// Overridden and Empty so that span tags are not written
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            
        }

        /// <summary>
        /// Overridden and Empty so that span tags are not written
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
                
        }		
		
		/// <summary>
      	/// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
      	/// </summary>
		protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
      	{
         int pos = 0;

         if (dataBinding)
         {
            //Instantiate the Header template (if exists)
            if (m_headerTemplate != null)
            {
                Control headerItem = new Control();
                m_headerTemplate.InstantiateIn(headerItem);
                Controls.Add(headerItem);
            }
			if (dataSource != null)
			{
				foreach (object o in dataSource)
				{
						HearbalKartDB.Entities.Orders entity = o as HearbalKartDB.Entities.Orders;
						OrdersItem container = new OrdersItem(entity);
	
						if (m_itemTemplate != null && (pos % 2) == 0)
						{
							m_itemTemplate.InstantiateIn(container);
							
							if (m_seperatorTemplate != null)
							{
								m_seperatorTemplate.InstantiateIn(container);
							}
						}
						else
						{
							if (m_altenateItemTemplate != null)
							{
								m_altenateItemTemplate.InstantiateIn(container);
								
								if (m_seperatorTemplate != null)
								{
									m_seperatorTemplate.InstantiateIn(container);
								}
								
							}
							else if (m_itemTemplate != null)
							{
								m_itemTemplate.InstantiateIn(container);
								
								if (m_seperatorTemplate != null)
								{
									m_seperatorTemplate.InstantiateIn(container);
								}
							}
							else
							{
								// no template !!!
							}
						}
						Controls.Add(container);
						
						container.DataBind();
						
						pos++;
				}
			}
            //Instantiate the Footer template (if exists)
            if (m_footerTemplate != null)
            {
                Control footerItem = new Control();
                m_footerTemplate.InstantiateIn(footerItem);
                Controls.Add(footerItem);
            }

		}
			
			return pos;
		}

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.PreRender"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> object that contains the event data.</param>
		protected override void OnPreRender(EventArgs e)
		{
			base.DataBind();
		}

		#region Design time
        /// <summary>
        /// Renders at design time.
        /// </summary>
        /// <returns>a  string of the Designed HTML</returns>
		internal string RenderAtDesignTime()
		{			
			return "Designer currently not implemented"; 
		}

		#endregion
	}

    /// <summary>
    /// A wrapper type for the entity
    /// </summary>
	[System.ComponentModel.ToolboxItem(false)]
	public class OrdersItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private HearbalKartDB.Entities.Orders _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:OrdersItem"/> class.
        /// </summary>
		public OrdersItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:OrdersItem"/> class.
        /// </summary>
		public OrdersItem(HearbalKartDB.Entities.Orders entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the Id
        /// </summary>
        /// <value>The Id.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 Id
		{
			get { return _entity.Id; }
		}
        /// <summary>
        /// Gets the CustomerId
        /// </summary>
        /// <value>The CustomerId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? CustomerId
		{
			get { return _entity.CustomerId; }
		}
        /// <summary>
        /// Gets the OrderStatusId
        /// </summary>
        /// <value>The OrderStatusId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? OrderStatusId
		{
			get { return _entity.OrderStatusId; }
		}
        /// <summary>
        /// Gets the BillingId
        /// </summary>
        /// <value>The BillingId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? BillingId
		{
			get { return _entity.BillingId; }
		}
        /// <summary>
        /// Gets the TotalAmount
        /// </summary>
        /// <value>The TotalAmount.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64? TotalAmount
		{
			get { return _entity.TotalAmount; }
		}
        /// <summary>
        /// Gets the SurveyId
        /// </summary>
        /// <value>The SurveyId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? SurveyId
		{
			get { return _entity.SurveyId; }
		}
        /// <summary>
        /// Gets the IsActive
        /// </summary>
        /// <value>The IsActive.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? IsActive
		{
			get { return _entity.IsActive; }
		}
        /// <summary>
        /// Gets the IsDeliver
        /// </summary>
        /// <value>The IsDeliver.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? IsDeliver
		{
			get { return _entity.IsDeliver; }
		}
        /// <summary>
        /// Gets the IsSurveyDone
        /// </summary>
        /// <value>The IsSurveyDone.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? IsSurveyDone
		{
			get { return _entity.IsSurveyDone; }
		}
        /// <summary>
        /// Gets the BookingDate
        /// </summary>
        /// <value>The BookingDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? BookingDate
		{
			get { return _entity.BookingDate; }
		}
        /// <summary>
        /// Gets the CreatedDate
        /// </summary>
        /// <value>The CreatedDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? CreatedDate
		{
			get { return _entity.CreatedDate; }
		}
        /// <summary>
        /// Gets the ModifiedDate
        /// </summary>
        /// <value>The ModifiedDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? ModifiedDate
		{
			get { return _entity.ModifiedDate; }
		}
        /// <summary>
        /// Gets the DeletedDate
        /// </summary>
        /// <value>The DeletedDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? DeletedDate
		{
			get { return _entity.DeletedDate; }
		}

        /// <summary>
        /// Gets a <see cref="T:HearbalKartDB.Entities.Orders"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public HearbalKartDB.Entities.Orders Entity
        {
            get { return _entity; }
        }
	}
}
