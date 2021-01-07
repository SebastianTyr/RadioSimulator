var map = L.map('radioMap').setView([50.049683, 19.944544], 12);

L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
}).addTo(map);

var policeMarker = L.marker([50.068544, 20.013084]).addTo(map);

L.marker([50.0347, 19.9402]).addTo(map)
    .bindPopup('Emergency <br><br> <button id="emergencyReport" class="btn">Report alarm</button>');

L.marker([50.0725, 19.9013]).addTo(map)
    .bindPopup('Fire Brigade <br><br> <button id="fireReport" class="btn">Report alarm</button>');

function policeMarker() {
    L.Routing.control({
        waypoints: [
            L.latLng(50.068544, 20.013084),
            L.latLng(50.055701, 19.977236)
        ],
        routeWhileDragging: true,
        createMarker: function marker(i, wp, n) {
            return L.marker(L.latLng(50.055701, 19.977236), { draggable: 'true' }).addTo(map)
                .bindPopup("");
        }
    }).addTo(map);
}

var policeAlarm = $('<div>Police Office <br><br> <button id="policeReport" class="btn">Report alarm</button></div>').click(function () {
    policeMarker();
})[0];

policeMarker.bindPopup(policeAlarm);