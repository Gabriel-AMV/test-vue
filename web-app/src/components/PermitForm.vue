<template>
  <div>
    <b-modal
      id="permitFormModal"
      hide-footer
      :header-bg-variant="'dark'"
      :header-text-variant="'light'"
      size="lg"
    >
      <template v-slot:modal-title>Permiso</template>
      <form @submit.prevent="AddOrEdit()">
        <div class="d-block">
          <b-row>
            <b-col>
              <label>Nombres:</label>
              <b-input  v-model="permit.nombreEmpleado" size="sm"></b-input>
            </b-col>
          </b-row>
          <b-row>
            <b-col>
              <label>Apellidos:</label>
              <b-input  v-model="permit.apellidosEmpleado" size="sm"></b-input>
            </b-col>
          </b-row>
          <b-row>
            <b-col>
              <label>Fecha:</label>
              <b-form-datepicker  v-model="permit.fecha" size="sm" type="date"></b-form-datepicker>
            </b-col>
          </b-row>
          <b-row>
            <b-col>
              <label>Tipo de permiso:</label>
              <b-form-select
                
                v-model="permit.tipoPermisoId"
                :options="permitTypes"
                size="sm"
              ></b-form-select>
            </b-col>
          </b-row>
          <br />
          <b-button
            type="submit"
            class="float-right"
            variant="success"
          >{{permit.isEdit ? "Editar" : "Solicitar"}}</b-button>
        </div>
      </form>
    </b-modal>
  </div>
</template>

<script>
export default {
  name: "PermitForm",
  props: {
    permit: {},
  },
  data() {
    return {
      baseUrl: "https://localhost:44321/",
      permitTypes: [],
    };
  },
  created() {
    this.axios.get(this.baseUrl + "api/permitstype").then((response) => {
      this.permitTypes = response.data.map((x) => {
        return {
          value: x.id,
          text: x.descripcion,
        };
      });
    });
  },
  methods: {
    catchError(errMessage) {
      console.log(errMessage);
      this.$swal("Ops!", "Ha ocurrido un error", "error");
    },

    launchToast(message, title) {
      this.$bvToast.toast(message, {
        title: title,
        autoHideDelay: 5000,
      });
    },

    validate() {
      if (!this.permit.nombreEmpleado) {
          console.log('hey')
        this.launchToast("El nombre es requerido", "Campos incompletos");
        return false;
      }

      if (!this.permit.apellidosEmpleado) {
        this.launchToast("El apellido es requerido", "Campos incompletos");
        return false;
      }

      if (!this.permit.fecha) {
        this.launchToast("La fecha es requerida", "Campos incompletos");
        return false;
      }

      if (!this.permit.tipoPermisoId) {
        this.launchToast("El permiso es requerido", "Campos incompletos");
        return false;
      }

      return true;
    },

    AddOrEdit() {
      if (this.validate()) {
        this.permit.tipoPermiso = null;
        if (this.permit.isEdit) {
          this.axios
            .put(this.baseUrl + "api/permits/" + this.permit.id, this.permit)
            .then(() => {
              this.$swal("¡Bien hecho!", "Permiso editado", "success").then(
                this.$bvModal.hide("permitFormModal")
              );
            })
            .catch(this.catchError);
        } else {
          this.axios
            .post(this.baseUrl + "api/permits", this.permit)
            .then(() => {
              this.$swal("¡Bien hecho!", "Permiso solicitado", "success").then(
                () => {
                  this.$bvModal.hide("permitFormModal");
                }
              );
            });
        }
      }
    },
  },
};
</script>
