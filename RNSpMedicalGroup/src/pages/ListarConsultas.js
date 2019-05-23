import React, { Component } from 'react';
import { View, Text, Image, StyleSheet, Alert, ScrollView } from "react-native";
import { FlatList } from 'react-native-gesture-handler';
import api from "../services/api";
import jwtDecode from "jwt-decode";

export default class ListarConsultas extends Component {

  constructor(props) {
    super(props);

    this.state = {
      listaConsultas: [],
      token: ""
    }
  }

  static navigationOptions = {
    header: null
  }

  componentDidMount() {
    this.carregarConsulta();
  };

  carregarConsulta = async () => {
    let token = await AsyncStorage.getItem('userToken');
    const resposta = await api.get('/Consultas', {
      headers: {
        'Authorization': "Bearer" + token
      }
    });
    const dadosDaApi = resposta.data;
    this.setState({ listaConsultas: dadosDaApi });
  }

  render() {
    return (
      <View style={styles.main}>
        <View style={styles.flexTitle}>
          <Text style={styles.title}>{"Consultas".toUpperCase()}</Text>
        </View>
          <View style={styles.after} />
      </View>
    );
  }
}

const styles = StyleSheet.create({
  main: {
    flex: 1,
    backgroundColor: "#F1F1F1"
  },
  flexTitle: {
    flex: 1,
    justifyContent: "center",
    marginTop: 80,
    flexDirection: "row"
  },
  title: {
    fontSize: 21,
    letterSpacing: 5,
    color: "#73D0F8"
  },
  after: {
    width: 170,
    height: 5,
    paddingTop: 10,
    borderBottomColor: "#727272",
    borderBottomWidth: 0.9
  }


});