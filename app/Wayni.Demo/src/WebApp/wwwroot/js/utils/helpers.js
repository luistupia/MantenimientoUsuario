function generateRandomSeed() {
    return Math.random().toString(36).substring(2, 15) + Math.random().toString(36).substring(2, 15);
}
function generateAvatarURL() {
    const seed = generateRandomSeed();
    return `https://robohash.org/${seed}.png`;
}

async function postJson(url, data) {
    try {
        const response = await fetch(url, {
            method: "POST",
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify(data)
        });
        const jsonResponse = await response.json();
        if (!jsonResponse.success) {
            throw new Error(jsonResponse.message || "Ocurrió un error inesperado.");
        }
        return jsonResponse;
    } catch (error) {
        console.error("Error al realizar la solicitud POST:", error);
        alert(`Ocurrió un error: ${error.message}`);
        return "";
    }
}

async function getJson(url) {
    try {
        const response = await fetch(url, {
            method: "GET",
            headers: {
                'Content-Type': "application/json"
            }
        });

        const jsonResponse = await response.json();
        if (!jsonResponse.success) {
            throw new Error(jsonResponse.message || "Ocurrió un error inesperado.");
        }

        return jsonResponse;
    } catch (error) {
        console.error("Error al realizar la solicitud GET:", error);
        alert(`Ocurrió un error: ${error.message}`);
        return "";
    }
}

formValidate = (e, idForm) => {
    const form = document.getElementById(idForm);
    const isValid = form.checkValidity();
    if (!isValid) {
        e.preventDefault();
        e.stopPropagation();
        form.classList.add("was-validated");
        return false;
    }
    return true;
};

function removeClassValidated(idForm) {
    const form = document.getElementById(idForm);
    form.classList.remove('was-validated');
}