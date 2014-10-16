var HexGridBuilder = function (width, depth, margin) {
	this.width = width || 10;
	this.depth = depth || 10;
	this.margin = margin || 1.0;
	this._hexWidth = 1.0;
	this._hexDepth = 1.0;
	this._initialPosition = BABYLON.Vector3.Zero();
};

HexGridBuilder.prototype.calculateInitialPosition = function () {
	var position = BABYLON.Vector3.Zero();
	position.x = -this._hexWidth * this.width / 2.0 + this._hexWidth / 2.0;
	position.z = this.depth / 2.0 * this._hexDepth / 2.0;
	return position;
};

HexGridBuilder.prototype.getWorldCoordinate = function (x, y, z) {
	var offset = 0.0;
	
	if (z % 2 !== 0) {
		offset = this._hexWidth / 2.0;
	}
	
	var px = this._initialPosition.x + offset + x * this._hexWidth * this.margin;
	var pz = this._initialPosition.z - z * this._hexDepth * 0.75 * this.margin;

	return new BABYLON.Vector3(px, y, pz);
};

HexGridBuilder.prototype.generate = function (scene) {
	var grid = new BABYLON.Mesh("Grid", scene);
	grid.isVisible = false;
	
	var prefab = BABYLON.Mesh.CreateCylinder("hex", 1, 3, 3, 6, 1, scene, false);
	prefab.rotation.y += Math.PI / 6;
	prefab.material = new BABYLON.StandardMaterial("gridMat", scene);
	prefab.material.diffuseTexture = new BABYLON.Texture("assets/images/blue.png", scene);
	
	var boundingInfo = prefab.getBoundingInfo();
	this._hexWidth = boundingInfo.maximum.z - boundingInfo.minimum.z;
	this._hexDepth = boundingInfo.maximum.x - boundingInfo.minimum.x;
	this._initialPosition = this.calculateInitialPosition();
	
	var tile = null;
	for (var z = 0; z < this.depth; z++) {
		for (var x = 0; x < this.width; x++) {
			tile = prefab.clone();
			tile.position = this.getWorldCoordinate(x, 0, z);
			tile.hexPosition = new BABYLON.Vector3(x, 0, z);
			tile.parent = grid;
		}
	} 
	
	prefab.dispose();
};