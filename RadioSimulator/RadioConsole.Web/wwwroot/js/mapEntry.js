var map = L.map('radioMap').setView([50.049683, 19.944544], 12);

L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
}).addTo(map);

L.marker([50.068544, 20.013084]).addTo(map)
    .bindPopup('Police <br><br> <button id="policeReport" class="btn" onlick="policeAlarm()">Report alarm</button>');

L.marker([50.0347, 19.9402]).addTo(map)
    .bindPopup('Emergency <br><br> <button id="emergencyReport" class="btn" onlick="emergencyAlarm()">Report alarm</button>');

L.marker([50.0725, 19.9013]).addTo(map)
    .bindPopup('Fire Brigade <br><br> <button id="fireReport" class="btn" onlick="fireAlarm()">Report alarm</button>');

function policeAlarm() {
    L.Routing.control({
        waypoints: [
            L.latLng(50.068544, 20.013084),
            L.latLng(50.065489, 19.975024)
        ],
        routeWhileDragging: true
    }).addTo(map);
};

function emergencyAlarm() {
    L.Routing.control({
        waypoints: [
            L.latLng(50.0347, 19.9402),
            L.latLng(50.044383, 19.926755)
        ],
        routeWhileDragging: true
    }).addTo(map);
};

function fireAlarm() {
    L.Routing.control({
        waypoints: [
            L.latLng(50.0725, 19.9013),
            L.latLng(50.061908, 19.941013)
        ],
        routeWhileDragging: true
    }).addTo(map);
};