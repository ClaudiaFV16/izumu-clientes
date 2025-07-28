// Validaciones del frontend para el formulario de clientes
function validarFormularioCliente() {
    const form = document.querySelector('form');
    const inputs = form.querySelectorAll('input[required], select[required]');
    let isValid = true;

    // Limpiar mensajes de error previos
    limpiarMensajesError();

    // Validar campos requeridos
    inputs.forEach(input => {
        if (!input.value.trim()) {
            mostrarError(input, 'Este campo es obligatorio');
            isValid = false;
        }
    });

    // Validar email
    const email = document.getElementById('Email');
    if (email && email.value) {
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailRegex.test(email.value)) {
            mostrarError(email, 'El formato del email no es válido');
            isValid = false;
        }
    }

    // Validar número de celular
    const celular = document.getElementById('NumeroCelular');
    if (celular && celular.value) {
        const celularRegex = /^\d{10}$/;
        if (!celularRegex.test(celular.value.replace(/\s/g, ''))) {
            mostrarError(celular, 'El número de celular debe tener 10 dígitos');
            isValid = false;
        }
    }

    // Validar fecha de nacimiento
    const fechaNac = document.getElementById('FechaNacimiento');
    if (fechaNac && fechaNac.value) {
        const fecha = new Date(fechaNac.value);
        const hoy = new Date();
        const edad = hoy.getFullYear() - fecha.getFullYear();
        
        if (edad < 0 || edad > 120) {
            mostrarError(fechaNac, 'La fecha de nacimiento no es válida');
            isValid = false;
        }
    }

    return isValid;
}

function mostrarError(input, mensaje) {
    const errorDiv = document.createElement('div');
    errorDiv.className = 'text-danger mt-1';
    errorDiv.textContent = mensaje;
    errorDiv.style.fontSize = '0.875rem';
    
    input.classList.add('is-invalid');
    input.parentNode.appendChild(errorDiv);
}

function limpiarMensajesError() {
    const errores = document.querySelectorAll('.text-danger');
    const inputsInvalidos = document.querySelectorAll('.is-invalid');
    
    errores.forEach(error => error.remove());
    inputsInvalidos.forEach(input => input.classList.remove('is-invalid'));
}

// Validar en tiempo real
document.addEventListener('DOMContentLoaded', function() {
    const form = document.querySelector('form');
    if (form) {
        form.addEventListener('submit', function(e) {
            if (!validarFormularioCliente()) {
                e.preventDefault();
                return false;
            }
        });

        // Validar email en tiempo real
        const email = document.getElementById('Email');
        if (email) {
            email.addEventListener('blur', function() {
                if (this.value) {
                    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
                    if (!emailRegex.test(this.value)) {
                        mostrarError(this, 'El formato del email no es válido');
                    } else {
                        this.classList.remove('is-invalid');
                        const errorDiv = this.parentNode.querySelector('.text-danger');
                        if (errorDiv) errorDiv.remove();
                    }
                }
            });
        }

        // Validar celular en tiempo real
        const celular = document.getElementById('NumeroCelular');
        if (celular) {
            celular.addEventListener('blur', function() {
                if (this.value) {
                    const celularRegex = /^\d{10}$/;
                    if (!celularRegex.test(this.value.replace(/\s/g, ''))) {
                        mostrarError(this, 'El número de celular debe tener 10 dígitos');
                    } else {
                        this.classList.remove('is-invalid');
                        const errorDiv = this.parentNode.querySelector('.text-danger');
                        if (errorDiv) errorDiv.remove();
                    }
                }
            });
        }
    }
}); 