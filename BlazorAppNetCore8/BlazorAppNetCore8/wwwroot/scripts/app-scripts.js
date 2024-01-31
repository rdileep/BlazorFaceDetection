const video = document.getElementById('video')

Promise.all([
    faceapi.nets.tinyFaceDetector.loadFromUri('/modelsV2'),
    faceapi.nets.faceLandmark68Net.loadFromUri('/modelsV2'),
    faceapi.nets.faceRecognitionNet.loadFromUri('/modelsV2'),
    faceapi.nets.faceExpressionNet.loadFromUri('/modelsV2')
]).then(startVideo)

function startVideo() {
    navigator.getUserMedia(
        { video: {} },
        stream => video.srcObject = stream,
        err => console.error(err)
    )
}
function drawBox(canvas, box) {
    const ctx = canvas.getContext("2d");
    ctx.beginPath();
    ctx.rect(box.x, box.y, box.width, box.height);
    ctx.stroke();
}
video.addEventListener('play', () => {
    const canvas = faceapi.createCanvasFromMedia(video)
    document.body.append(canvas)
    const displaySize = { width: video.width, height: video.height }
    faceapi.matchDimensions(canvas, displaySize)    
    setInterval(async () => {
        /* Display detected face bounding boxes */
        const detections = await faceapi.detectAllFaces(video, new faceapi.TinyFaceDetectorOptions());
        // resize the detected boxes in case your displayed image has a different size than the original
        const resizedDetections = faceapi.resizeResults(detections, displaySize);
        // draw detections into the canvas
        faceapi.draw.drawDetections(canvas, resizedDetections);
        if (resizedDetections != undefined && resizedDetections.length > 0 && resizedDetections[0].box != undefined) {
            console.log(resizedDetections[0].box.x);
            drawBox(canvas, resizedDetections[0].box);
        }
        
        ////const detections = await faceapi.detectAllFaces(video, new faceapi.TinyFaceDetectorOptions()).withFaceLandmarks().withFaceExpressions()
        //console.log("detecting faces:");
        //const detections = await faceapi.detectAllFaces(video, new faceapi.TinyFaceDetectorOptions()).withFaceLandmarks();
        //console.log("faces detected:");
        //console.log(detections[0].landmarks);
        //const resizedDetections = faceapi.resizeResults(detections, displaySize)
        //canvas.getContext('2d').clearRect(0, 0, canvas.width, canvas.height)
        //faceapi.draw.drawDetections(canvas, resizedDetections)
        //faceapi.draw.drawFaceLandmarks(canvas, resizedDetections)
        ////faceapi.draw.drawFaceExpressions(canvas, resizedDetections)
    }, 1000)
})