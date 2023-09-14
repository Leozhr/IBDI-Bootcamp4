function viewToast(mensagem) {
    Toastify({
        text: mensagem,
        duration: 3000,
        close: true,
        gravity: "top",
        position: "center",
        style: {
            background: "#dc3444"
        }
    }).showToast();
}

viewToast();