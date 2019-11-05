import React, { Component } from 'react';
import { Text, View, FlatList, StyleSheet, AsyncStorage, Image } from 'react-native';

export default class Main extends Component {

    static navigationOptions = {
        tabBarIcon: () => (
            <Image
                source={require('../assets/img/home.png')}
                style={styles.tabBarNavigatorIcon}
            />
        ),
    };

    constructor() {
        super();
        this.state = {
            aulas: [],
            idUsuarioNavigation: [],
            idTemaNavigation: [],

            nome: ""

        };
    }

    componentDidMount() {
        this._carregarAulas();
    }

    _carregarAulas = async () => {
        console.warn('ahhh>_--', await AsyncStorage.getItem('@roman:token'))
        await fetch('http://192.168.4.203:5000/api/aulas', {
            headers: {
                'Authorization': 'Bearer ' + await AsyncStorage.getItem('@roman:token'),
                'Content-Type': 'application/json',
            }
        })
            .then(resposta => resposta.json())
            .then(data => this.setState({ aulas: data }))
            .catch(erro => console.warn(erro));
    };

    render() {
        return (
            <FlatList style={styles.total}
                data={this.state.aulas}
                keyExtractor={item => item.idAula}
                renderItem={({ item }) => (
                    <View >
                        <Text style={styles.titulo}>{item.nome}</Text>
                        <Text style={styles.item}>{item.idUsuarioNavigation.nome}</Text>
                        <Text style={styles.item_dois}>{item.idTemaNavigation.nome}</Text>
                    </View>
                )}
            />
        );
    }
}

const styles = StyleSheet.create({
    tabBarNavigatorIcon: {
        width: 25,
        height: 25,
        backgroundColor: 'white'
    },
    total: {
        backgroundColor: '#111826',
        padding: 50

    },

    titulo: {
        fontSize: 30,
        backgroundColor: '#2493BF',
        textAlign: "center",
        borderRadius: 5,
        borderWidth: 1.5,
        borderColor: "black",
    },

    item: {
        fontSize: 20,
        backgroundColor: '#6CBAD9',
        textAlign: "center",
        borderRadius: 5,
        borderWidth: 1,
        borderColor: "black",
    },

    item_dois: {
        fontSize: 20,
        backgroundColor: '#D8E6F2',
        textAlign: "center",
        marginBottom: 40,
        borderRadius: 5,
        borderWidth: 1,
        borderColor: "black",
    }
});
