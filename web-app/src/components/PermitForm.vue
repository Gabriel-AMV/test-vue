<template>
  <div>
    <b-modal
      id="permitFormModal"
      hide-footer
      :header-bg-variant="'dark'"
      :header-text-variant="'light'"
      size="lg"
    >
      <template v-slot:modal-title>
       Permiso
      </template>
      <div class="d-block">
        <b-row>
          <b-col>
            <label>Nombres:</label>
            <b-input v-model="permit.nombreEmpleado" size="sm"></b-input>
          </b-col>
        </b-row>
        <b-row>
          <b-col>
            <label>Apellidos:</label>
            <b-input v-model="permit.apellidosEmpleado" size="sm"></b-input>
          </b-col>
        </b-row>
        <b-row>
          <b-col>
            <label>Fecha:</label>
            <b-form-datepicker v-model="permit.fecha" size="sm" type="date"></b-form-datepicker>
          </b-col>
        </b-row>
        <b-row>
          <b-col>
            <label>Tipo de permiso:</label>
            <b-form-select v-model="permit.tipoPermisoId" :options="permitTypes" size="sm"></b-form-select>
          </b-col>

        </b-row>
        <br />
        <b-button class="float-right" v-on:click="AddOrEdit()" variant="success" size="sm">
          <b-icon icon="file-earmark-check"></b-icon>Guardar
        </b-button>
      </div>
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
    validate() {
      let success = true;

      if (!this.permit.nombreEmpleado) {
        this.$bvToast.toast("El nombre del empleado es requerido", {
          title: "Atención",
          variant: "warning",
          solid: true,
        });
        success = false;
      }

      if (!this.permit.apellidosEmpleado) {
        this.$bvToast.toast("Los apellidos del empleado son requeridos", {
          title: "Atención",
          variant: "warning",
          solid: true,
        });

        success = false;
      }

      if (!this.permit.fecha) {
        this.$bvToast.toast("La fecha es requerida", {
          title: "Atención",
          variant: "warning",
          solid: true,
        });

        success = false;
      }

      if (!this.permit.tipoPermisoId) {
        this.$bvToast.toast("El tipo de permiso es requerido", {
          title: "Atención",
          variant: "warning",
          solid: true,
        });

        success = false;
      }

      return success;
    },
    catchError(errMessage) {
      console.log(errMessage);
      this.$swal("Ops!", "Ha ocurrido un error", "error");
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
              this.$swal("¡Bien hecho!", "Permiso agregado", "success").then(
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
