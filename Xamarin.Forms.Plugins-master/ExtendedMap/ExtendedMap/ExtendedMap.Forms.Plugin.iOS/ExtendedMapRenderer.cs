﻿using System;
using System.Collections.Specialized;
using System.Linq;
using CoreLocation;
using ExtendedMap.Forms.Plugin.Abstractions;
using ExtendedMap.Forms.Plugin.Abstractions.Models;
using ExtendedMap.Forms.Plugin.iOS;
using ExtendedMap.Forms.Plugin.iOS.Models;
using MapKit;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof (ExtendedMap.Forms.Plugin.Abstractions.ExtendedMap), typeof (ExtendedMapRenderer))]

namespace ExtendedMap.Forms.Plugin.iOS
{
  /// <summary>
  ///   ExtendedMap Renderer
  /// </summary>
  public class ExtendedMapRenderer : MapRenderer
  {
    public static void Init()
    {
    }

    #region private properties

    private MKMapView _nativeMapView
    {
      get { return Control as MKMapView; }
    }

    private Abstractions.ExtendedMap _customMap
    {
      get { return Element as Abstractions.ExtendedMap; }
    }

    private CustomMapContentView _customMapContentView
    {
      get { return _customMap.Parent.Parent as CustomMapContentView; }
    }

    #endregion private properties
  
    protected override void OnElementChanged(ElementChangedEventArgs<View> e)
    {
      base.OnElementChanged(e);

      var mapDelegate = new MapDelegate();
      mapDelegate.MapTapped += MapDelegateOnMapTapped;
	_nativeMapView.Delegate = null;
      _nativeMapView.Delegate = mapDelegate;

      _customMap.CustomPins.CollectionChanged += HandleCollectionChanged;
    }

    private void MapDelegateOnMapTapped(object sender, EventArgs eventArgs)
    {
		_customMapContentView.Footer.FooterMode = FooterMode.Hidden;
    }

	protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
	{
		base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName.Equals(Abstractions.ExtendedMap.CenterOnPositionProperty.PropertyName) )
		{
				CenterOnLocation(new CLLocationCoordinate2D(_customMap.CenterOnPosition.Latitude, _customMap.CenterOnPosition.Longitude),
				_customMapContentView.Footer.FooterMode);
		}
	}

		private void CenterOnLocation(CLLocationCoordinate2D coordinates, FooterMode footerMode)
		{
			var center = coordinates;

			if(footerMode == FooterMode.Hidden || footerMode == FooterMode.Minimized)
			{
				center.Latitude -= _nativeMapView.Region.Span.LatitudeDelta * 0.10;
			}
			else{
				center.Latitude -= _nativeMapView.Region.Span.LatitudeDelta * 0.35;
			}

			_nativeMapView.SetCenterCoordinate (center, true);
		}
    

    private void HandleCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      if (e.Action == NotifyCollectionChangedAction.Add)
      {
        var pin = e.NewItems[0] as ExtendedPin;
        AddPin(pin);
      }
    }

    private void AddPin(ExtendedPin formsPin)
    {
      var nativePin =
        new ExtendedMapAnnotation(new CLLocationCoordinate2D(formsPin.Position.Latitude, formsPin.Position.Longitude),
          formsPin.Label, formsPin.Address, formsPin.PinIcon);

      nativePin.Clicked += HandleAnnotationClick;

      _nativeMapView.AddAnnotation(nativePin);
    }

    private void HandleAnnotationClick(object sender, ExtendedMapAnnotation e)
    {
      _customMap.SelectedPinAddress = e.Subtitle;

      if (_customMapContentView.Footer.FooterMode == FooterMode.Hidden)
      {
        _customMapContentView.Footer.FooterMode = FooterMode.Minimized;
      }
    }
  }
}