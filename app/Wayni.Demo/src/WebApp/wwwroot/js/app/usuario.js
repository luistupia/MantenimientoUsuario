const { createApp } = Vue;
const app = createApp({
    data() {
        return {
            cargaAvatarSpinner: false,
            guardarUsuarioSpinner: false,
            obtenerUsuSpinner: false,
            flgEditar: false,
            listaUsuarios: [],
            cargaUsuarios: true,
            usuario: {
                Avatar: "https://robohash.org/default.png"
            },
            modalRegistro: null
        };
    },
    directives: {
        'solo-numeros': {
            mounted(el) {
                el.addEventListener('input', function (e) {
                    e.target.value = e.target.value.replace(/\D/g, '');
                });
            }
        },
        'solo-texto': {
            mounted(el) {
                el.addEventListener('input', function (e) {
                    e.target.value = e.target.value.replace(/[^a-zA-Z\s]/g, '');
                });
            }
        }
    },
    created: function () {
        this.listarUsuarios();
    },
    mounted() {
        this.$nextTick(() => {
            const modalElement = document.getElementById("mdRegistro");
            if (modalElement) {
                this.modalRegistro = new bootstrap.Modal(modalElement, {
                    keyboard: false
                });
            }
        });
    },
    methods: {
        generarAvatar() {
            const v = this;
            v.cargaAvatarSpinner = true;
            const avatar = generateAvatarURL();
            const img = new Image();
            img.src = avatar;
            img.onload = function () {
                v.usuario.Avatar = avatar;
                v.cargaAvatarSpinner = false;
            };
        },
        async listarUsuarios() {
            const response = await getJson("/usuarios/listar");
            this.listaUsuarios = response.result;
        },
        async guardar(e) {
            const validaform = formValidate(e, "frmRegistro");
            if (!validaform) return;

            this.guardarUsuarioSpinner = true;
            const payload = this.usuario;

            const url = this.flgEditar ? "/usuarios/modificar" : "/usuarios/registrar";
            const response = await postJson(url, payload);

            this.guardarUsuarioSpinner = false;
            alert(response.message);
            this.modalRegistro.hide();
            this.nuevoRegistro();
            this.listarUsuarios();
        },
        async obtenerUsuario(usuario) {
            this.obtenerUsuSpinner = true;
            this.modalRegistro.show();
            this.flgEditar = true;

            const id = usuario.Id;
            const response = await getJson(`/usuarios/${id}`);
            if (!response.success) this.modalRegistro.hide();

            this.usuario = response.result;
            this.obtenerUsuSpinner = false;
        },
        async eliminarUsuario(id) {
            const payload = {
                Id: id
            };
            const conf = confirm("¿Está seguro de eliminar el registro?");
            if (!conf) return;
            const response = await postJson("/usuarios/eliminar", payload);
            if (!response.success) {
                alert(response.message);
                return;
            } 
            this.listarUsuarios();
        },
        cerrarModal() {
            this.modalRegistro.hide();
            this.nuevoRegistro();
        },
        nuevoRegistro() {
            this.usuario = {};
            this.usuario.Avatar = "https://robohash.org/default.png";
            this.guardarUsuarioSpinner = false;
            this.obtenerUsuSpinner = false;
            this.flgEditar = false;
            removeClassValidated("frmRegistro");
        }
    }
});
app.mount('#app');