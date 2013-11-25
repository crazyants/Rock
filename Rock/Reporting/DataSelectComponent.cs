﻿using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI;
using Rock.Extension;

namespace Rock.Reporting
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class DataSelectComponent : Component
    {
        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public abstract string Title { get; }

        /// <summary>
        /// Gets the name of the entity type.
        /// </summary>
        /// <value>
        /// The name of the entity type.
        /// </value>
        public abstract string EntityTypeName { get; }

        /// <summary>
        /// Gets the default column header text.
        /// </summary>
        /// <value>
        /// The default column header text.
        /// </value>
        public abstract string ColumnHeaderText { get; }

        /// <summary>
        /// Gets the section.
        /// </summary>
        /// <value>
        /// The section.
        /// </value>
        public virtual string Section
        {
            get { return "Other"; }
        }

        /// <summary>
        /// Gets the attribute value defaults.
        /// </summary>
        /// <value>
        /// The attribute defaults.
        /// </value>
        public override Dictionary<string, string> AttributeValueDefaults
        {
            get
            {
                var defaults = new Dictionary<string, string>();
                defaults.Add( "Active", "True" );
                return defaults;
            }
        }

        /// <summary>
        /// Formats the selection on the client-side.  When the widget is collapsed by the user, the Filterfield control
        /// will set the description of the filter to whatever is returned by this property.  If including script, the
        /// controls parent container can be referenced through a '$content' variable that is set by the control before
        /// referencing this property.
        /// </summary>
        /// <returns></returns>
        /// <value>
        /// The client format script.
        ///   </value>
        public virtual string GetClientFormatSelection()
        {
            return this.Title;
        }

        /// <summary>
        /// Formats the selection.
        /// </summary>
        /// <param name="selection">The selection.</param>
        /// <returns></returns>
        public virtual string FormatSelection( string selection )
        {
            return this.Title;
        }

        /// <summary>
        /// Creates the child controls.
        /// </summary>
        /// <returns></returns>
        public virtual Control[] CreateChildControls( Control parentControl )
        {
            return new Control[0];
        }

        /// <summary>
        /// Renders the controls.
        /// </summary>
        /// <param name="parentControl">The parent control.</param>
        /// <param name="writer">The writer.</param>
        /// <param name="controls">The controls.</param>
        public virtual void RenderControls( Control parentControl, HtmlTextWriter writer, Control[] controls )
        {
            foreach ( var control in controls )
            {
                control.RenderControl( writer );
                writer.WriteLine();
            }
        }

        /// <summary>
        /// Gets the selection.
        /// </summary>
        /// <param name="controls">The controls.</param>
        /// <returns></returns>
        public virtual string GetSelection( Control[] controls )
        {
            return string.Empty;
        }

        /// <summary>
        /// Sets the selection.
        /// </summary>
        /// <param name="controls">The controls.</param>
        /// <param name="selection">The selection.</param>
        public virtual void SetSelection( Control[] controls, string selection )
        {
            string[] selectionValues = selection.Split( '|' );
        }

        /// <summary>
        /// Returns an IQueryable that contains the additional column provided by this component
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameterExpression">The parameter expression.</param>
        /// <returns></returns>
        public abstract IQueryable AddColumn(IQueryable query, ParameterExpression parameterExpression);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class DataSelectComponent<T> : DataSelectComponent
    {
        
    }
}