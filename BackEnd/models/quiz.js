module.exports = (sequelize, DataTypes) => {

    const Quiz = sequelize.define("Quiz",{
        quizID:{
            type: DataTypes.INTEGER,
            allowNull: false,
            autoIncrement: true,
            primaryKey: true,
        },
        title:{
            type: DataTypes.STRING,
            allowNull: false,
        },
        numQ:{
            type: DataTypes.INTEGER,
            allowNull: false,
        },
    });

    Quiz.associate = (models) => {
        Quiz.hasMany(models.Question, {
            foreignKey: "quizID",
        });
    };

    return Quiz
}