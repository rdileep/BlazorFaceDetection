using Microsoft.AspNetCore.Mvc;

namespace BlazorAppNetCore8.Controllers
{

    
    public class FileServeController : Controller
    {
        IWebHostEnvironment env;
        public FileServeController(IWebHostEnvironment hostEnvironment)
        {
            env = hostEnvironment;
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        public IActionResult test()
        {
            return Content(
                "yeahhh... working...",
                "text/plain"
            );
        }

        [HttpGet("[controller]/age_gender_model-shard1")]
        public async Task<IActionResult> AgeGenderModelShard1() => Content(
                await System.IO.File.ReadAllTextAsync(Path.Combine(env.WebRootPath, "models", "age_gender_model-shard1")),
                "text/plain"
            );

        [HttpGet("[controller]/tiny_face_detector_model-shard1")]
        public async Task<IActionResult> Tinyfacedetectormodelshard1() => Content(
                await System.IO.File.ReadAllTextAsync(Path.Combine(env.WebRootPath, "models", "tiny_face_detector_model-shard1")),
                "text/plain"
            );


        [HttpGet("[controller]/face_landmark_68_model-shard1")]
        public async Task<IActionResult> FaceLandmark68ModelShard1() => Content(
                await System.IO.File.ReadAllTextAsync(Path.Combine(env.WebRootPath, "models", "face_landmark_68_model-shard1")),
                "text/plain"
            );
        
        [HttpGet("[controller]/face_landmark_68_tiny_model-shard1")]
        public async Task<IActionResult> FaceLandmark68TinyModelShard1() => Content(
                await System.IO.File.ReadAllTextAsync(Path.Combine(env.WebRootPath, "models", "face_landmark_68_tiny_model-shard1")),
                "text/plain"
            );


        [HttpGet("[controller]/face_recognition_model-shard1")]
        public async Task<IActionResult> FaceRecognitionModelShard1() => Content(
                await System.IO.File.ReadAllTextAsync(Path.Combine(env.WebRootPath, "models", "face_recognition_model-shard1")),
                "text/plain"
            );

        [HttpGet("[controller]/face_expression_model-shard1")]
        public async Task<IActionResult> FaceExpressionModelShard1() => Content(
                await System.IO.File.ReadAllTextAsync(Path.Combine(env.WebRootPath, "models", "face_expression_model-shard1")),
                "text/plain"
            );

        [HttpGet("[controller]/face_recognition_model-shard2")]
        public async Task<IActionResult> FaceRecognitionModelShard2() => Content(
                await System.IO.File.ReadAllTextAsync(Path.Combine(env.WebRootPath, "models", "face_recognition_model-shard2")),
                "text/plain"
            );

        [HttpGet("[controller]/mtcnn_model-shard1")]
        public async Task<IActionResult> MtcnnModelShard1() => Content(
                await System.IO.File.ReadAllTextAsync(Path.Combine(env.WebRootPath, "models", "mtcnn_model-shard1")),
                "text/plain"
            );

        [HttpGet("[controller]/ssd_mobilenetv1_model-shard1")]
        public async Task<IActionResult> SsdMobilenetv1ModelShard1() => Content(
                await System.IO.File.ReadAllTextAsync(Path.Combine(env.WebRootPath, "models", "ssd_mobilenetv1_model-shard1")),
                "text/plain"
            );

        [HttpGet("[controller]/ssd_mobilenetv1_model-shard2")]
        public async Task<IActionResult> SsdMobilenetv1ModelShard2() => Content(
                await System.IO.File.ReadAllTextAsync(Path.Combine(env.WebRootPath, "models", "ssd_mobilenetv1_model-shard2")),
                "text/plain"
            );


        //MANIJEST.JSON FILES
        [HttpGet("[controller]/age_gender_model-weights_manifest.json")]
        public async Task<IActionResult> AgeGenderModelWeightsManifestJson() => Content(
                await System.IO.File.ReadAllTextAsync(Path.Combine(env.WebRootPath, "models", "age_gender_model-weights_manifest.json")),
                "application/json"
            );

        [HttpGet("[controller]/face_landmark_68_model-weights_manifest.json")]
        public async Task<IActionResult> FaceLandmark68ModelWeightsManifestJson() => Content(
                await System.IO.File.ReadAllTextAsync(Path.Combine(env.WebRootPath, "models", "face_landmark_68_model-weights_manifest.json")),
                "application/json"
            );

        [HttpGet("[controller]/face_landmark_68_tiny_model-weights_manifest.json")]
        public async Task<IActionResult> FaceLandmark68TinyModelWeightsManifestJson() => Content(
                await System.IO.File.ReadAllTextAsync(Path.Combine(env.WebRootPath, "models", "face_landmark_68_tiny_model-weights_manifest.json")),
                "application/json"
            );

        [HttpGet("[controller]/tiny_face_detector_model-weights_manifest.json")]
        public async Task<IActionResult> Tinyfacedetectormodelweightsmanifestjson() => Content(
                await System.IO.File.ReadAllTextAsync(Path.Combine(env.WebRootPath, "models", "tiny_face_detector_model-weights_manifest.json")),
                "application/json"
            );

        [HttpGet("[controller]/face_recognition_model-weights_manifest.json")]
        public async Task<IActionResult> FaceRecognitionModelWeightsManifestJson() => Content(
                await System.IO.File.ReadAllTextAsync(Path.Combine(env.WebRootPath, "models", "face_recognition_model-weights_manifest.json")),
                "application/json"
            );

        [HttpGet("[controller]/mtcnn_model-weights_manifest.json")]
        public async Task<IActionResult> MtcnnModelWeightsManifestJson() => Content(
                await System.IO.File.ReadAllTextAsync(Path.Combine(env.WebRootPath, "models", "mtcnn_model-weights_manifest.json")),
                "application/json"
            );

        [HttpGet("[controller]/ssd_mobilenetv1_model-weights_manifest.json")]
        public async Task<IActionResult> SsdMobilenetv1ModelWeightsManifestJson() => Content(
                await System.IO.File.ReadAllTextAsync(Path.Combine(env.WebRootPath, "models", "ssd_mobilenetv1_model-weights_manifest.json")),
                "application/json"
            );

        [HttpGet("[controller]/face_expression_model-weights_manifest.json")]
        public async Task<IActionResult> FaceExpressionModelWeightsManifestJson() => Content(
                await System.IO.File.ReadAllTextAsync(Path.Combine(env.WebRootPath, "models", "face_expression_model-weights_manifest.json")),
                "application/json"
            );


    }
}
