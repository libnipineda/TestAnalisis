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
    const data = req.body;
    informacion.push(data);

    if (informacion) {
        res.json({
            "respuesta": "Datos ingresados correctamente!!",
            "informacion": console.log(req.body)
        });
    } else {
        res.status(404).json({
            "error": "El servidor ha encontrado una situacion que no sabe como manejarla!"
        });
    }

    informacion.forEach((item, index) => {
        console.log('indice: ' + index + ' valor: ' + item);
    });
})

router.get('/api/data:codigo', (req, res) => {
    const codigo = req.params.codigo;
    console.log(codigo);
    const elemento = informacion.find((d) => d.codigo === codigo);
    console.log(elemento);
    if (elemento) {
        res.json({
            "respuesta": "dato encontrado",
            "texto": item
        })
    } else {
        res.status(404).json({
            "error": "No se encontro el dato!!!"
        })
    }
})

module.exports = router;