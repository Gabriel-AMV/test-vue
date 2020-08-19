<template>
  <b-container>
    <b-row>
      <b-col>
        <h4 class="font-weight-bold">Tipos de Permisos</h4>
      </b-col>
      <b-col>
        <br />
        <b-button
          @click="addOrEditModal({})"
          size="sm"
          class="float-right"
          variant="outline-success"
        >
          <b-icon icon="plus"></b-icon>Agregar
        </b-button>
      </b-col>
    </b-row>
  <br>
        <table class="table table-bordered">
      <thead>
        <tr>
          <th>Descripcion:</th>
          <th>Acciones</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(pt, i) in permitsType" :key="i">
          <td>{{ pt.descripcion }}</td>
          <td>
            <b-button @click="addOrEditModal(pt)" size="sm" class="linkWarning" variant="link">
              <b-icon icon="pencil"></b-icon>
            </b-button>
            <b-button @click="remove(pt)" size="sm" class="linkDanger" variant="link">
              <b-icon icon="x"></b-icon>
            </b-button>
          </td>
        </tr>
      </tbody>
    </table>

    <b-modal
      id="addPermitType"
      hide-footer
      :header-bg-variant="'dark'"
      :header-text-variant="'light'"
    >
      <template v-slot:modal-title>Agregar</template>
      <label>Descripción:</label>
      <b-input v-model="selectedPermitType.descripcion" size="sm"></b-input>
      <br />
      <b-button variant="light" @click="$bvModal.hide('addPermitType')">Cancelar</b-button>&nbsp;
      <b-button variant="success" @click="addOrEdit()">{{message}}</b-button>
    </b-modal>
  </b-container>
</template>

<script>
export default {
  name: "TypePermits",

  data() {
    return {
      message: "",
      isEdit: false,
      permitsType: [],
      selectedPermitType: {},
      baseUrl: "https://localhost:44321/api/permitsType/",
    };
  },
  created() {
    this.loadPermitsType();
  },

  methods: {
    loadPermitsType() {
      this.axios.get(this.baseUrl).then((response) => {
        this.permitsType = response.data;
      });
    },

    addOrEditModal(obj) {
      this.selectedPermitType = obj;

      if (this.selectedPermitType.id) {
        this.message = "Editar";
        this.isEdit = true;
      } else {
        this.message = "Agregar";
        this.isEdit = false;
      }
      this.$bvModal.show("addPermitType");
    },
    catchError(errMessage){
          console.log(errMessage);
          this.$swal("Ops!", "Ha ocurrido un error", "error");
    },
    addOrEdit() {
      if (this.isEdit === false) {
        this.axios
          .post(this.baseUrl, {
            Descripcion: this.selectedPermitType.descripcion,
          })
          .then(() => {
            this.$swal(
              "¡Bien hecho!",
              "Tipo de permiso agregado",
              "success"
            ).then(() => {
              this.loadPermitsType();
              this.$bvModal.hide("addPermitType");
            });
          })
          .catch(this.catchError);
      } else {
        this.axios
          .put(this.baseUrl + this.selectedPermitType.id, {
            Id: this.selectedPermitType.id,
            Descripcion: this.selectedPermitType.descripcion,
          })
          .then(() => {
            this.$swal(
              "¡Bien hecho!",
              "Tipo de permiso agregado",
              "success"
            ).then(() => {
              this.loadPermitsType();
              this.$bvModal.hide("addPermitType");
            });
          })
          .catch(this.catchError);
      }

      this.$bvModal.show("addPermitType");
    },

    remove(obj) {
      this.$swal({
        title: `¿Seguro que desea eliminar el permiso "${obj.descripcion}"?`,
        text: "No podra recuperar la información",
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
        .delete(this.baseUrl + obj.id)
        .then(() => {
          this.$swal(
            "¡Eliminado!",
            "La información ha sido eliminada",
            "success"
          );
          this.loadPermitsType();
        })
        .catch((err) => {
          console.log(err);
          this.$swal("Ops!", "Ha ocurrido un error", "error");
        });
    },
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