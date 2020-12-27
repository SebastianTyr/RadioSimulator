var map = new ol.Map({
    target: 'map',
    layers: [
        new ol.layer.Tile({
            source: new ol.source.OSM()
        })
    ],
    view: new ol.View({
        center: ol.proj.fromLonLat([19.944544, 50.049683]),
        zoom: 12
    })
});

const marker = new khtml.maplib.overlay.Marker({
	position: new khtml.maplib.LatLng(50.068544, 20.013084),
	icon: {
		url: '../../Assets/Marker.png',
		size: { width: 26, height: 32 },
		origin: { x: 0, y: 0 },
		anchor: {
			x: "-10px",
			y: "-32px"
		}
	},
	shadow: {
		url: "http://maps.gstatic.com/intl/de_de/mapfiles/ms/micons/pushpin_shadow.png",
		size: {
			width: "40px",
			height: "32px"
		},
		origin: { x: 0, y: 0 },
		anchor: { x: 0, y: -32 }
	},
	draggable: false,
	title: "static"
});