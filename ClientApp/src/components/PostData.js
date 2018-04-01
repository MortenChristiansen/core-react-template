import React, { Component } from "react";

export class PostData extends Component {

    constructor(props) {
        super(props);
        this.state = { items: [], loading: true };

        fetch('/api/sampledata/getitems')
            .then(response => response.json())
            .then(data => {
                this.setState({
                    items: data,
                    loading: false
                });
            });
    };

    save(e) {
        console.log('someone pressed save!');
        e.preventDefault();

        var newItem = {
            name: document.getElementById('itemName').value,
            description: document.getElementById('itemDescription').value
        };

        console.log(newItem);

        fetch('/api/sampledata/newitem', {
            body: JSON.stringify(newItem),
            method: 'POST',
            headers: {
                'content-type': 'application/json'
            }
        })
            .then(response => response.json())
            .then(data => {
                this.setState({ items: data, loading: false });
            });
    }

    render() {
        return (
            <div className="row">
                <div className="col-md-4">
                    <h1>Bæst</h1>
                    <form>
                        <div className="form-group">
                            <label htmlFor="itemName">Name:</label>
                            <input type="text" className="form-control" id="itemName" />
                        </div>
                        <div className="form-group">
                            <label htmlFor="itemDescription">Description:</label>
                            <input type="text" className="form-control" id="itemDescription" />
                        </div>
                        <button type="submit" className="btn btn-primary" onClick={(e) => this.save(e)}>Save</button>
                    </form>
                </div>
                <div className="col-md-12">
                    <table className="table" style={{ marginTop: '50px' }}>
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>Description</th>
                                <th>Completed</th>
                            </tr>
                        </thead>
                        <tbody>
                            {this.state.items.map(item =>
                                <tr key={item.id}>
                                    <td>{item.name}</td>
                                    <td>{item.description}</td>
                                    <td>{item.isComplete.toString()}</td>
                                </tr>
                            )}
                        </tbody>
                    </table>
                </div>
            </div>
        );
    };
}