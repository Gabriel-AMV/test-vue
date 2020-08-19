<template>
  <div>
    <b-container>
      <b-row>
        <b-col>
          <h4 class="font-weight-bold">Permisos</h4>
        </b-col>
        <b-col>
          <br />
          <b-button @click="AddOrEdit({})" size="sm" class="float-right " variant="outline-success">
            <b-icon icon="plus"></b-icon>Agregar
          </b-button>
        </b-col>
      </b-row>
      <br>
      <table class="table table-sm table-bordered">
        <thead>
          <tr >
            <th>
              <b-icon icon="hash"></b-icon>
            </th>
            <th>Empleado:</th>
            <th>Tipo de permiso:</th>
            <th>Fecha:</th>
            <th>Opciones:</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(permit, i) in permits" :key="i">
            <td>{{ i + 1}}</td>
            <td>{{ permit.nombreEmpleado }} {{ permit.apellidosEmpleado }}</td>
            <td>{{ permit.tipoPermiso }}</td>
            <td>{{ permit.fecha | datefilter  }}</td>
            <td>
              <b-button @click="AddOrEdit(permit, true)" size="sm" class="linkWarning" variant="link">
                <b-icon icon="pencil"></b-icon>
              </b-button>
              <b-button
                @click="remove(permit)"
                size="sm"
                class="linkDanger"
                variant="link"
              >
                <b-icon icon="x"></b-icon>
              </b-button>
            </td>
          </tr>
        </tbody>
      </table>
      <PermitsForm :permit="selectedPermit" />
    </b-container>
  </div>
</template>

<script>
import PermitsForm from "../components/PermitForm";

export default {
  name: "Permits",
  components: {
    PermitsForm,
  },
  data () {
    return {
      permits: [],
      selectedPermit: {},
      baseUrl: "https://localhost:44321/",
    };
  },
  created() {
    this.loadPermits();
  },
  methods: {
    AddOrEdit (obj, isEdit = false) {
      this.selectedPermit = {...obj, isEdit : isEdit};
      if (this.selectedPermit.fecha)
        this.selectedPermit.fecha = new Date(this.selectedPermit.fecha);
      this.$bvModal.show("permitFormModal");
    },

    loadPermits () {
      this.axios.get(this.baseUrl + "api/permits").then((response) => {
        this.permits = response.data;
      });
    },

   remove(obj) {
      this.$swal({
        title: `¿Seguro que desea eliminar la información?`,
        text: `Se eliminará el permiso ${obj.tipoPermiso} para el empleado ${obj.nombreEmpleado + ' ' + obj.apellidosEmpleado }`,
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Si, eliminalo",
      }).then((result) => {
        if (result.value) {
          this.removeConfirmed(obj);
        }
      });
    },

    removeConfirmed(obj) {
      console.log(obj.id, obj);
      this.axios
        .delete(this.baseUrl + 'api/permits/' + obj.id)
        .then(() => {
          this.$swal(
            "¡Eliminado!",
            "La información ha sido eliminada",
            "success"
          );
          this.loadPermits();
        })
        .catch((err) => {
          console.log(err);
          this.$swal("Ops!", "Ha ocurrido un error", "error");
        });
    },
  },
  mounted() {
    this.$root.$on("bv::modal::hide", () => {
      this.loadPermits();
    });
  },
};
</script>

<style scoped>
.linkWarning {
  color: #daa404 !important;
}

.linkDanger {
  color: #b60c0c !important;
}
</style>