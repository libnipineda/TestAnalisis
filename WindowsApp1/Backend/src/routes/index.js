const { Router } = require('express');
const router = Router();


let informacion = [];

// Raiz
router.get('/', (req, res) => {
    res.json({
        "Title": "Bienvenido al servidor de Node JS!!!!",
        "Autor": "Libni Pineda"
    });
})


router.post('/api/datos', (req, res) => {
    informacion.push(req.body)

    if (informacion) {
        res.json({
            "respuesta": "Datos ingresados correctamente!!",
            "informacion": informacion.toString()
        });
    } else {
        res.status(500).json({
            "error": "El servidor ha encontrado una situacion que no sabe como manejarla!"
        });
    }
})

module.exports = router;