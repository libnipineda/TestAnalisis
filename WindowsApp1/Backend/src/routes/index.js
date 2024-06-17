const { Router } = require('express');
const router = Routre();


// Raiz
router.get('/', (req, res) => {
    res.json({
        "Title": "Bienvenido al servidor de Node JS!!!!"
    });
})

module.exports = router;