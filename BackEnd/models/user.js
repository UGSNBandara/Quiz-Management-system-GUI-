module.exports = (sequelize, DataTypes) => {

    const User = sequelize.define("User",{
        username:{
            type: DataTypes.STRING,
            allowNull: false,
        },
        name:{
            type: DataTypes.STRING,
            allowNull: false,
        },
        password:{
            type: DataTypes.STRING,
            allowNull: false,
        },
        email:{
            type: DataTypes.STRING,
            allowNull : false,
        },
        completedQ:{
            type: DataTypes.STRING,
            allowNull: false,
        },
        totalMarks:{
            type: DataTypes.DOUBLE,
            allowNull: false,
        },
    });

    return User
}
