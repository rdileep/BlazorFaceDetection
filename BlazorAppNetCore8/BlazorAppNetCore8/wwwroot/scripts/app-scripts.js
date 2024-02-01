const video = document.getElementById('video');
const videoArea = document.getElementById('divVideoArea');
const logArea = document.getElementById('divLogArea');


Promise.all([
    faceapi.nets.tinyFaceDetector.loadFromUri('/modelsV2'),
    faceapi.nets.faceLandmark68Net.loadFromUri('/modelsV2'),
    faceapi.nets.faceRecognitionNet.loadFromUri('/modelsV2'),
    faceapi.nets.faceExpressionNet.loadFromUri('/modelsV2')
]).then(startVideo)

function startVideo() {
    navigator.getUserMedia(
        {
            video: {
                frameRate: { ideal: 10, max: 15 }
            }
        },
        stream => video.srcObject = stream,
        err => console.error(err)
    )
}


video.addEventListener('play', () => {
    const canvas = faceapi.createCanvasFromMedia(video)
    canvas.style = "position:absolute;";
    videoArea.append(canvas)
    const displaySize = { width: video.width, height: video.height }
    faceapi.matchDimensions(canvas, displaySize)
    setInterval(async () => {
        /* Display detected face bounding boxes */
        //const detections = await faceapi.detectAllFaces(video, new faceapi.TinyFaceDetectorOptions())
        //    .withFaceLandmarks()
        //    .withFaceExpressions()
        //    .withFaceDescriptors();

        //const detections = await faceapi.detectSingleFace(video, new faceapi.SsdMobilenetv1Options({ minConfidence: 0.85 }))
        const detections = await faceapi.detectSingleFace(video, new faceapi.TinyFaceDetectorOptions({ inputSize: 320, scoreThreshold: 0.5 }))
            .withFaceLandmarks()
            .withFaceExpressions()
            .withFaceDescriptor();
        if (detections != undefined) {
            // resize the detected boxes in case your displayed image has a different size than the original
            const resizedDetections = faceapi.resizeResults(detections, displaySize);
            canvas.getContext('2d').clearRect(0, 0, canvas.width, canvas.height);
            // draw detections into the canvas
            faceapi.draw.drawDetections(canvas, resizedDetections);
            faceapi.draw.drawFaceLandmarks(canvas, resizedDetections);
            faceapi.draw.drawFaceExpressions(canvas, resizedDetections);
            logArea.innerText = detections.descriptor;
        }
        else {
            canvas.getContext('2d').clearRect(0, 0, canvas.width, canvas.height);
        }
    }, 100)
})