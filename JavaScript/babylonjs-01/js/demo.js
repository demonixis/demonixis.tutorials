'use strict';

function runDemo(canvasId) {
	var canvas = document.getElementById(canvasId);
	var engine = new BABYLON.Engine(canvas, true);
	
	// Création de la scène
	var scene = new BABYLON.Scene(engine);
    scene.gravity = new BABYLON.Vector3(0, -9.81, 0);
	scene.collisionsEnabled = true;
    
	// Ajout d'une caméra et de son contrôleur
    var camera = new BABYLON.FreeCamera("MainCamera", new BABYLON.Vector3(0, 2.5, 5), scene);
    camera.applyGravity = true;
    camera.checkCollisions = true;
	
	camera.speed = 0.5;
	camera.angularSensibility = 1000;
	
	camera.keysUp = [90]; // Touche Z
	camera.keysDown = [83]; // Touche S
	camera.keysLeft = [81]; // Touche Q
	camera.keysRight = [68]; // Touche D;
	scene.activeCamera.attachControl(canvas);
	
	// Ajout d'une lumière
	var light = new BABYLON.PointLight("DirLight", new BABYLON.Vector3(0, 10, 0), scene);
	light.diffuse = new BABYLON.Color3(1, 1, 1);
	light.specular = new BABYLON.Color3(0.6, 0.6, 0.6);
	light.intensity = 1.5;
	
	// On ajoute une skybox
	createSkybox(scene);
	
	// Enfin la scène de démo
	createDemoScene(scene);
	
	// Lancement de la boucle principale
	engine.runRenderLoop(function() {
		scene.render();
	});
}

function createSkybox(scene) {
	// Création d'une material
	var sMaterial = new BABYLON.StandardMaterial("skyboxMaterial", scene);
	sMaterial.backFaceCulling = false;
	sMaterial.reflectionTexture = new BABYLON.CubeTexture("images/skybox/skybox", scene);
	sMaterial.reflectionTexture.coordinatesMode = BABYLON.Texture.SKYBOX_MODE;
	
	// Création d'un cube avec la material adaptée
	var skybox = BABYLON.Mesh.CreateBox("skybox", 250, scene);
	skybox.material = sMaterial;
}

function createDemoScene(scene) {
	// Création d'un sol
	var ground = BABYLON.Mesh.CreatePlane("ground", 50, scene);
	ground.rotation.x = Math.PI / 2;
	ground.material = new BABYLON.StandardMaterial("gMaterial", scene);
	ground.material.diffuseTexture = new BABYLON.Texture("images/ground.png", scene);
	ground.checkCollisions = true;
	
	// Et quelques cubes...
	var boxMaterial = new BABYLON.StandardMaterial("bMaterial", scene);
	boxMaterial.diffuseTexture = new BABYLON.Texture("images/box.png", scene);
	
	var positions = [
		{ x: -15, z: 15 },
		{ x: -15, z: -15 },
		{ x: 15, z: 15 },
		{ x: 15, z: -15 }
	];
	
	var cubeSize = 2.5;
	
	for (var i = 0; i < 4; i++) {
		var box = BABYLON.Mesh.CreateBox("box1", cubeSize, scene);
		box.position = new BABYLON.Vector3(positions[i].x, cubeSize / 2, positions[i].z);
		box.material = boxMaterial;
		box.checkCollisions = true;
	}
}