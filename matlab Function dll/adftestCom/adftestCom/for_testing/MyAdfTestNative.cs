/*
* MATLAB Compiler: 6.2 (R2016a)
* Date: Sat Jul 22 05:10:15 2017
* Arguments: "-B" "macro_default" "-W" "dotnet:adftestCom,MyAdfTest,0.0,private" "-T"
* "link:lib" "-d" "C:\Users\Amjad\Desktop\adftestCom\adftestCom\for_testing" "-v"
* "class{MyAdfTest:C:\Program Files\MATLAB\R2016a\toolbox\econ\econ\adftest.m}" 
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace adftestComNative
{

  /// <summary>
  /// The MyAdfTest class provides a CLS compliant, Object (native) interface to the
  /// MATLAB functions contained in the files:
  /// <newpara></newpara>
  /// C:\Program Files\MATLAB\R2016a\toolbox\econ\econ\adftest.m
  /// </summary>
  /// <remarks>
  /// @Version 0.0
  /// </remarks>
  public class MyAdfTest : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Runtime instance.
    /// </summary>
    static MyAdfTest()
    {
      if (MWMCR.MCRAppInitialized)
      {
        try
        {
          Assembly assembly= Assembly.GetExecutingAssembly();

          string ctfFilePath= assembly.Location;

          int lastDelimiter= ctfFilePath.LastIndexOf(@"\");

          ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

          string ctfFileName = "adftestCom.ctf";

          Stream embeddedCtfStream = null;

          String[] resourceStrings = assembly.GetManifestResourceNames();

          foreach (String name in resourceStrings)
          {
            if (name.Contains(ctfFileName))
            {
              embeddedCtfStream = assembly.GetManifestResourceStream(name);
              break;
            }
          }
          mcr= new MWMCR("",
                         ctfFilePath, embeddedCtfStream, true);
        }
        catch(Exception ex)
        {
          ex_ = new Exception("MWArray assembly failed to be initialized", ex);
        }
      }
      else
      {
        ex_ = new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the MyAdfTest class.
    /// </summary>
    public MyAdfTest()
    {
      if(ex_ != null)
      {
        throw ex_;
      }
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~MyAdfTest()
    {
      Dispose(false);
    }


    /// <summary>
    /// Frees the native resources associated with this object
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }


    /// <summary internal= "true">
    /// Internal dispose function
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        disposed= true;

        if (disposing)
        {
          // Free managed resources;
        }

        // Free native resources
      }
    }


    #endregion Finalize

    #region Methods

    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the adftest MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// ADFTEST Augmented Dickey-Fuller test for a unit root
    /// Syntax:
    /// [h,pValue,stat,cValue,reg] = adftest(y)
    /// [h,pValue,stat,cValue,reg] = adftest(y,param1,val1,param2,val2,...)
    /// Description:
    /// Dickey-Fuller tests assess the null hypothesis of a unit root in a
    /// univariate time series y. All tests use the model
    /// y(t) = c + d*t + a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t),
    /// where L is the lag operator Ly(t) = y(t-1). The null hypothesis
    /// restricts a = 1. Variants of the test, appropriate for series with
    /// different growth characteristics, restrict the drift and deterministic
    /// trend coefficients, c and d, respectively, to be 0. Lagged differences
    /// bk*(1-L)y(t-k), k = 1, ..., p, "augment" the test to account for serial
    /// correlations in the innovations process e(t).
    /// Input Arguments:
    /// y - Vector of time-series data. The last element is the most recent
    /// observation. NaNs indicating missing values are removed.
    /// Optional Input Parameter Name/Value Pairs:
    /// NAME        VALUE
    /// 'lags'      Scalar or vector of nonnegative integers indicating the
    /// number p of lagged changes of y to include in the model.
    /// The default value is 0.
    /// 'model'     String or cell vector of strings indicating the model
    /// variant. Values are 'AR' (autoregressive), 'ARD'
    /// (autoregressive with drift), or 'TS' (trend stationary).
    /// The default value is 'AR'.
    /// o When the value is 'AR', the null model
    /// y(t) = y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)                   
    /// is tested against the alternative model
    /// y(t) = a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)
    /// with AR(1) coefficient a &lt; 1.
    /// o When the value is 'ARD', the null model
    /// y(t) = y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)                   
    /// is tested against the alternative model
    /// y(t) = c + a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)
    /// with drift coefficient c and AR(1) coefficient a &lt; 1.
    /// o When the value is 'TS', the null model
    /// y(t) = c + y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)                   
    /// is tested against the alternative model
    /// y(t) = c + d*t + a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)
    /// with drift coefficient c, deterministic trend coefficient
    /// d, and AR(1) coefficient a &lt; 1. 
    /// 'test'      String or cell vector of strings indicating the type of
    /// test statistic. Values are 't1', 't2', or 'F'. The default
    /// value is 't1'. 
    /// o When the value is 't1', a standard t statistic
    /// t1 = (a-l)/se
    /// is computed from OLS estimates of the AR(1) coefficient a
    /// and its standard error se in the alternative model. The
    /// test assesses the significance of the restriction a = 1.
    /// o When the value is 't2', a lag-adjusted, "unstudentized" t
    /// statistic
    /// t2 = T*(a-1)/(1-b1-...-bp)
    /// is computed from OLS estimates of the AR(1) coefficient a
    /// and the stationary coefficients b1, ..., bp in the
    /// alternative model. T is the effective sample size,
    /// adjusted for lags and missing values. The test assesses
    /// the significance of the restriction a = 1.
    /// o When the value is 'F', an F statistic is computed to
    /// assess the significance of a joint restriction on the
    /// alternative model. If the value of 'model' is 'ARD', the
    /// restriction is a = 1 and c = 0. If the value of 'model'
    /// is 'TS', the restriction is a = 1 and d = 0. An F test is
    /// invalid when the value of 'model' is 'AR'.
    /// 'alpha'     Scalar or vector of nominal significance levels for the
    /// tests. Values must be between 0.001 and 0.999. The default
    /// value is 0.05.
    /// Scalar or single string parameter values are expanded to the length of
    /// any vector value (the number of tests). Vector values must have equal
    /// length. If any value is a row vector, all outputs are row vectors.
    /// Output Arguments:
    /// h - Vector of Boolean decisions for the tests, with length equal to the
    /// number of tests. Values of h equal to 1 indicate rejection of the
    /// unit-root null in favor of the alternative model. Values of h equal
    /// to 0 indicate a failure to reject the unit-root null.
    /// pValue - Vector of p-values of the test statistics, with length equal
    /// to the number of tests. When the value of 'test' is 't1' or 't2',
    /// p-values are left-tail probabilities. When the value of 'test' is
    /// 'F', p-values are right-tail probabilities.
    /// stat - Vector of test statistics, with length equal to the number of
    /// tests. Statistics are computed using OLS estimates of the
    /// coefficients in the alternative model.
    /// cValue - Vector of critical values for the tests, with length equal to
    /// the number of tests. When the value of 'test' is 't1' or 't2',
    /// critical values are for left-tail probabilities. When the value of
    /// 'test' is 'F', critical values are for right-tail probabilities.
    /// reg - Structure of regression statistics from the OLS estimation of 
    /// coefficients in the alternative model. The number of records is
    /// equal to the number of tests. Each record has the following fields:
    /// num         Length of the input series y, with NaNs removed
    /// size        Effective sample size, adjusted for lags, difference*
    /// names       Regression coefficient names			
    /// coeff       Estimated coefficient values
    /// se          Estimated coefficient standard errors
    /// Cov         Estimated coefficient covariance matrix
    /// tStats      t statistics of coefficients and p-values
    /// FStat       F statistic and p-value
    /// yMu         Mean of y, adjusted for lags, difference*
    /// ySigma      Standard deviation of y, adjusted for lags, difference*
    /// yHat        Fitted values of y, adjusted for lags, difference*
    /// res         Regression residuals
    /// DWStat      Durbin-Watson statistic
    /// SSR         Regression sum of squares
    /// SSE         Error sum of squares
    /// SST         Total sum of squares
    /// MSE         Mean squared error
    /// RMSE        Standard error of the regression
    /// RSq         R^2 statistic
    /// aRSq        Adjusted R^2 statistic
    /// LL          Loglikelihood of data under Gaussian innovations
    /// AIC         Akaike information criterion
    /// BIC         Bayesian (Schwarz) information criterion
    /// HQC         Hannan-Quinn information criterion
    /// *Lagging and differencing a time series reduce the sample size.
    /// Absent any presample values, if y(t) is defined for t = 1:N, then
    /// the lagged series y(t-k) is defined for t = k+1:N. Differencing
    /// reduces the time base to k+2:N. With p lagged differences, the
    /// common time base is p+2:N and the effective sample size is N-(p+1).
    /// Notes:
    /// o A suitable value for 'lags' must be determined in order to draw valid
    /// inferences from the test. One method is to begin with a maximum lag,
    /// such as the one recommended by Schwert [7], and then test down by
    /// assessing the significance of the coefficient of the largest lagged
    /// change in y, bp. The usual t statistic is appropriate, as reported in
    /// the reg output structure. Another method is to combine a measure of
    /// fit, such as SSR, with information criteria such as AIC, BIC, and
    /// HQC. These statistics are also reported in the reg output structure.
    /// Ng and Perron [6] provide further guidelines.
    /// o The value of 'model' is determined by the growth characteristics of
    /// the time series being tested, and should be chosen with a specific
    /// testing strategy in mind. As discussed in Elder &amp; Kennedy [4],
    /// including too many regressors results in lost power, while including
    /// too few biases the test in favor of the null. In general, if a series
    /// is growing, the 'TS' model provides a reasonable trend-stationary
    /// alternative to a unit-root process with drift. If a series is not
    /// growing, 'AR' and 'ARD' models provide reasonable stationary
    /// alternatives to a unit-root process without drift. The 'ARD'
    /// alternative has mean c/(1-a); the 'AR' alternative has mean 0.
    /// o Dickey-Fuller statistics follow nonstandard distributions under the
    /// null, even asymptotically. Critical values for a range of sample
    /// sizes and significance levels have been tabulated using Monte Carlo
    /// simulations of the null model with Gaussian innovations and five
    /// million replications per sample size. For small samples, values are
    /// valid only for Gaussian innovations; for large samples, values are
    /// also valid for non-Gaussian innovations. Critical values and p-values
    /// are interpolated from the tables. Tables for tests of type 't1' and
    /// 't2' are identical to those for PPTEST.
    /// Example:
    /// Test GDP data for a unit root using a trend-stationary alternative
    /// with 0, 1, and 2 lagged differences:
    /// load Data_GDP
    /// y = log(Data);
    /// h = adftest(y,'model','TS','lags',0:2)
    /// The test fails to reject the unit-root null with each alternative.
    /// References:
    /// [1] Davidson, R. and J. G. MacKinnon. Econometric Theory and Methods.
    /// Oxford, UK: Oxford University Press, 2004.
    /// [2] Dickey, D. A., and W. A. Fuller. "Distribution of the Estimators
    /// for Autoregressive Time Series with a Unit Root." Journal of the
    /// American Statistical Association. Vol. 74, 1979, pp. 427-431.
    /// [3] Dickey, D. A., and W. A. Fuller. "Likelihood Ratio Statistics for
    /// Autoregressive Time Series with a Unit Root." Econometrica. Vol.
    /// 49, 1981, pp. 1057-1072.
    /// [4] Elder, J., and P. E. Kennedy. "Testing for Unit Roots: What Should
    /// Students Be Taught?" Journal of Economic Education. Vol. 32, 2001, 
    /// pp. 137-146.
    /// [5] Hamilton, J. D. Time Series Analysis. Princeton, NJ: Princeton
    /// University Press, 1994.
    /// [6] Ng, S., and P. Perron. "Unit Root Tests in ARMA Models with
    /// Data-Dependent Methods for the Selection of the Truncation Lag."
    /// Journal of the American Statistical Association. Vol. 90, 1995, 
    /// pp. 268-281.
    /// [7] Schwert, W. "Tests for Unit Roots: A Monte Carlo Investigation."
    /// Journal of Business and Economic Statistics. Vol. 7, 1989,
    /// pp. 147-159.
    /// See also PPTEST, LMCTEST, KPSSTEST, VRATIOTEST. 
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object adftest()
    {
      return mcr.EvaluateFunction("adftest", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the adftest MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// ADFTEST Augmented Dickey-Fuller test for a unit root
    /// Syntax:
    /// [h,pValue,stat,cValue,reg] = adftest(y)
    /// [h,pValue,stat,cValue,reg] = adftest(y,param1,val1,param2,val2,...)
    /// Description:
    /// Dickey-Fuller tests assess the null hypothesis of a unit root in a
    /// univariate time series y. All tests use the model
    /// y(t) = c + d*t + a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t),
    /// where L is the lag operator Ly(t) = y(t-1). The null hypothesis
    /// restricts a = 1. Variants of the test, appropriate for series with
    /// different growth characteristics, restrict the drift and deterministic
    /// trend coefficients, c and d, respectively, to be 0. Lagged differences
    /// bk*(1-L)y(t-k), k = 1, ..., p, "augment" the test to account for serial
    /// correlations in the innovations process e(t).
    /// Input Arguments:
    /// y - Vector of time-series data. The last element is the most recent
    /// observation. NaNs indicating missing values are removed.
    /// Optional Input Parameter Name/Value Pairs:
    /// NAME        VALUE
    /// 'lags'      Scalar or vector of nonnegative integers indicating the
    /// number p of lagged changes of y to include in the model.
    /// The default value is 0.
    /// 'model'     String or cell vector of strings indicating the model
    /// variant. Values are 'AR' (autoregressive), 'ARD'
    /// (autoregressive with drift), or 'TS' (trend stationary).
    /// The default value is 'AR'.
    /// o When the value is 'AR', the null model
    /// y(t) = y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)                   
    /// is tested against the alternative model
    /// y(t) = a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)
    /// with AR(1) coefficient a &lt; 1.
    /// o When the value is 'ARD', the null model
    /// y(t) = y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)                   
    /// is tested against the alternative model
    /// y(t) = c + a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)
    /// with drift coefficient c and AR(1) coefficient a &lt; 1.
    /// o When the value is 'TS', the null model
    /// y(t) = c + y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)                   
    /// is tested against the alternative model
    /// y(t) = c + d*t + a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)
    /// with drift coefficient c, deterministic trend coefficient
    /// d, and AR(1) coefficient a &lt; 1. 
    /// 'test'      String or cell vector of strings indicating the type of
    /// test statistic. Values are 't1', 't2', or 'F'. The default
    /// value is 't1'. 
    /// o When the value is 't1', a standard t statistic
    /// t1 = (a-l)/se
    /// is computed from OLS estimates of the AR(1) coefficient a
    /// and its standard error se in the alternative model. The
    /// test assesses the significance of the restriction a = 1.
    /// o When the value is 't2', a lag-adjusted, "unstudentized" t
    /// statistic
    /// t2 = T*(a-1)/(1-b1-...-bp)
    /// is computed from OLS estimates of the AR(1) coefficient a
    /// and the stationary coefficients b1, ..., bp in the
    /// alternative model. T is the effective sample size,
    /// adjusted for lags and missing values. The test assesses
    /// the significance of the restriction a = 1.
    /// o When the value is 'F', an F statistic is computed to
    /// assess the significance of a joint restriction on the
    /// alternative model. If the value of 'model' is 'ARD', the
    /// restriction is a = 1 and c = 0. If the value of 'model'
    /// is 'TS', the restriction is a = 1 and d = 0. An F test is
    /// invalid when the value of 'model' is 'AR'.
    /// 'alpha'     Scalar or vector of nominal significance levels for the
    /// tests. Values must be between 0.001 and 0.999. The default
    /// value is 0.05.
    /// Scalar or single string parameter values are expanded to the length of
    /// any vector value (the number of tests). Vector values must have equal
    /// length. If any value is a row vector, all outputs are row vectors.
    /// Output Arguments:
    /// h - Vector of Boolean decisions for the tests, with length equal to the
    /// number of tests. Values of h equal to 1 indicate rejection of the
    /// unit-root null in favor of the alternative model. Values of h equal
    /// to 0 indicate a failure to reject the unit-root null.
    /// pValue - Vector of p-values of the test statistics, with length equal
    /// to the number of tests. When the value of 'test' is 't1' or 't2',
    /// p-values are left-tail probabilities. When the value of 'test' is
    /// 'F', p-values are right-tail probabilities.
    /// stat - Vector of test statistics, with length equal to the number of
    /// tests. Statistics are computed using OLS estimates of the
    /// coefficients in the alternative model.
    /// cValue - Vector of critical values for the tests, with length equal to
    /// the number of tests. When the value of 'test' is 't1' or 't2',
    /// critical values are for left-tail probabilities. When the value of
    /// 'test' is 'F', critical values are for right-tail probabilities.
    /// reg - Structure of regression statistics from the OLS estimation of 
    /// coefficients in the alternative model. The number of records is
    /// equal to the number of tests. Each record has the following fields:
    /// num         Length of the input series y, with NaNs removed
    /// size        Effective sample size, adjusted for lags, difference*
    /// names       Regression coefficient names			
    /// coeff       Estimated coefficient values
    /// se          Estimated coefficient standard errors
    /// Cov         Estimated coefficient covariance matrix
    /// tStats      t statistics of coefficients and p-values
    /// FStat       F statistic and p-value
    /// yMu         Mean of y, adjusted for lags, difference*
    /// ySigma      Standard deviation of y, adjusted for lags, difference*
    /// yHat        Fitted values of y, adjusted for lags, difference*
    /// res         Regression residuals
    /// DWStat      Durbin-Watson statistic
    /// SSR         Regression sum of squares
    /// SSE         Error sum of squares
    /// SST         Total sum of squares
    /// MSE         Mean squared error
    /// RMSE        Standard error of the regression
    /// RSq         R^2 statistic
    /// aRSq        Adjusted R^2 statistic
    /// LL          Loglikelihood of data under Gaussian innovations
    /// AIC         Akaike information criterion
    /// BIC         Bayesian (Schwarz) information criterion
    /// HQC         Hannan-Quinn information criterion
    /// *Lagging and differencing a time series reduce the sample size.
    /// Absent any presample values, if y(t) is defined for t = 1:N, then
    /// the lagged series y(t-k) is defined for t = k+1:N. Differencing
    /// reduces the time base to k+2:N. With p lagged differences, the
    /// common time base is p+2:N and the effective sample size is N-(p+1).
    /// Notes:
    /// o A suitable value for 'lags' must be determined in order to draw valid
    /// inferences from the test. One method is to begin with a maximum lag,
    /// such as the one recommended by Schwert [7], and then test down by
    /// assessing the significance of the coefficient of the largest lagged
    /// change in y, bp. The usual t statistic is appropriate, as reported in
    /// the reg output structure. Another method is to combine a measure of
    /// fit, such as SSR, with information criteria such as AIC, BIC, and
    /// HQC. These statistics are also reported in the reg output structure.
    /// Ng and Perron [6] provide further guidelines.
    /// o The value of 'model' is determined by the growth characteristics of
    /// the time series being tested, and should be chosen with a specific
    /// testing strategy in mind. As discussed in Elder &amp; Kennedy [4],
    /// including too many regressors results in lost power, while including
    /// too few biases the test in favor of the null. In general, if a series
    /// is growing, the 'TS' model provides a reasonable trend-stationary
    /// alternative to a unit-root process with drift. If a series is not
    /// growing, 'AR' and 'ARD' models provide reasonable stationary
    /// alternatives to a unit-root process without drift. The 'ARD'
    /// alternative has mean c/(1-a); the 'AR' alternative has mean 0.
    /// o Dickey-Fuller statistics follow nonstandard distributions under the
    /// null, even asymptotically. Critical values for a range of sample
    /// sizes and significance levels have been tabulated using Monte Carlo
    /// simulations of the null model with Gaussian innovations and five
    /// million replications per sample size. For small samples, values are
    /// valid only for Gaussian innovations; for large samples, values are
    /// also valid for non-Gaussian innovations. Critical values and p-values
    /// are interpolated from the tables. Tables for tests of type 't1' and
    /// 't2' are identical to those for PPTEST.
    /// Example:
    /// Test GDP data for a unit root using a trend-stationary alternative
    /// with 0, 1, and 2 lagged differences:
    /// load Data_GDP
    /// y = log(Data);
    /// h = adftest(y,'model','TS','lags',0:2)
    /// The test fails to reject the unit-root null with each alternative.
    /// References:
    /// [1] Davidson, R. and J. G. MacKinnon. Econometric Theory and Methods.
    /// Oxford, UK: Oxford University Press, 2004.
    /// [2] Dickey, D. A., and W. A. Fuller. "Distribution of the Estimators
    /// for Autoregressive Time Series with a Unit Root." Journal of the
    /// American Statistical Association. Vol. 74, 1979, pp. 427-431.
    /// [3] Dickey, D. A., and W. A. Fuller. "Likelihood Ratio Statistics for
    /// Autoregressive Time Series with a Unit Root." Econometrica. Vol.
    /// 49, 1981, pp. 1057-1072.
    /// [4] Elder, J., and P. E. Kennedy. "Testing for Unit Roots: What Should
    /// Students Be Taught?" Journal of Economic Education. Vol. 32, 2001, 
    /// pp. 137-146.
    /// [5] Hamilton, J. D. Time Series Analysis. Princeton, NJ: Princeton
    /// University Press, 1994.
    /// [6] Ng, S., and P. Perron. "Unit Root Tests in ARMA Models with
    /// Data-Dependent Methods for the Selection of the Truncation Lag."
    /// Journal of the American Statistical Association. Vol. 90, 1995, 
    /// pp. 268-281.
    /// [7] Schwert, W. "Tests for Unit Roots: A Monte Carlo Investigation."
    /// Journal of Business and Economic Statistics. Vol. 7, 1989,
    /// pp. 147-159.
    /// See also PPTEST, LMCTEST, KPSSTEST, VRATIOTEST. 
    /// </remarks>
    /// <param name="y">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object adftest(Object y)
    {
      return mcr.EvaluateFunction("adftest", y);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the adftest MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// ADFTEST Augmented Dickey-Fuller test for a unit root
    /// Syntax:
    /// [h,pValue,stat,cValue,reg] = adftest(y)
    /// [h,pValue,stat,cValue,reg] = adftest(y,param1,val1,param2,val2,...)
    /// Description:
    /// Dickey-Fuller tests assess the null hypothesis of a unit root in a
    /// univariate time series y. All tests use the model
    /// y(t) = c + d*t + a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t),
    /// where L is the lag operator Ly(t) = y(t-1). The null hypothesis
    /// restricts a = 1. Variants of the test, appropriate for series with
    /// different growth characteristics, restrict the drift and deterministic
    /// trend coefficients, c and d, respectively, to be 0. Lagged differences
    /// bk*(1-L)y(t-k), k = 1, ..., p, "augment" the test to account for serial
    /// correlations in the innovations process e(t).
    /// Input Arguments:
    /// y - Vector of time-series data. The last element is the most recent
    /// observation. NaNs indicating missing values are removed.
    /// Optional Input Parameter Name/Value Pairs:
    /// NAME        VALUE
    /// 'lags'      Scalar or vector of nonnegative integers indicating the
    /// number p of lagged changes of y to include in the model.
    /// The default value is 0.
    /// 'model'     String or cell vector of strings indicating the model
    /// variant. Values are 'AR' (autoregressive), 'ARD'
    /// (autoregressive with drift), or 'TS' (trend stationary).
    /// The default value is 'AR'.
    /// o When the value is 'AR', the null model
    /// y(t) = y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)                   
    /// is tested against the alternative model
    /// y(t) = a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)
    /// with AR(1) coefficient a &lt; 1.
    /// o When the value is 'ARD', the null model
    /// y(t) = y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)                   
    /// is tested against the alternative model
    /// y(t) = c + a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)
    /// with drift coefficient c and AR(1) coefficient a &lt; 1.
    /// o When the value is 'TS', the null model
    /// y(t) = c + y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)                   
    /// is tested against the alternative model
    /// y(t) = c + d*t + a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)
    /// with drift coefficient c, deterministic trend coefficient
    /// d, and AR(1) coefficient a &lt; 1. 
    /// 'test'      String or cell vector of strings indicating the type of
    /// test statistic. Values are 't1', 't2', or 'F'. The default
    /// value is 't1'. 
    /// o When the value is 't1', a standard t statistic
    /// t1 = (a-l)/se
    /// is computed from OLS estimates of the AR(1) coefficient a
    /// and its standard error se in the alternative model. The
    /// test assesses the significance of the restriction a = 1.
    /// o When the value is 't2', a lag-adjusted, "unstudentized" t
    /// statistic
    /// t2 = T*(a-1)/(1-b1-...-bp)
    /// is computed from OLS estimates of the AR(1) coefficient a
    /// and the stationary coefficients b1, ..., bp in the
    /// alternative model. T is the effective sample size,
    /// adjusted for lags and missing values. The test assesses
    /// the significance of the restriction a = 1.
    /// o When the value is 'F', an F statistic is computed to
    /// assess the significance of a joint restriction on the
    /// alternative model. If the value of 'model' is 'ARD', the
    /// restriction is a = 1 and c = 0. If the value of 'model'
    /// is 'TS', the restriction is a = 1 and d = 0. An F test is
    /// invalid when the value of 'model' is 'AR'.
    /// 'alpha'     Scalar or vector of nominal significance levels for the
    /// tests. Values must be between 0.001 and 0.999. The default
    /// value is 0.05.
    /// Scalar or single string parameter values are expanded to the length of
    /// any vector value (the number of tests). Vector values must have equal
    /// length. If any value is a row vector, all outputs are row vectors.
    /// Output Arguments:
    /// h - Vector of Boolean decisions for the tests, with length equal to the
    /// number of tests. Values of h equal to 1 indicate rejection of the
    /// unit-root null in favor of the alternative model. Values of h equal
    /// to 0 indicate a failure to reject the unit-root null.
    /// pValue - Vector of p-values of the test statistics, with length equal
    /// to the number of tests. When the value of 'test' is 't1' or 't2',
    /// p-values are left-tail probabilities. When the value of 'test' is
    /// 'F', p-values are right-tail probabilities.
    /// stat - Vector of test statistics, with length equal to the number of
    /// tests. Statistics are computed using OLS estimates of the
    /// coefficients in the alternative model.
    /// cValue - Vector of critical values for the tests, with length equal to
    /// the number of tests. When the value of 'test' is 't1' or 't2',
    /// critical values are for left-tail probabilities. When the value of
    /// 'test' is 'F', critical values are for right-tail probabilities.
    /// reg - Structure of regression statistics from the OLS estimation of 
    /// coefficients in the alternative model. The number of records is
    /// equal to the number of tests. Each record has the following fields:
    /// num         Length of the input series y, with NaNs removed
    /// size        Effective sample size, adjusted for lags, difference*
    /// names       Regression coefficient names			
    /// coeff       Estimated coefficient values
    /// se          Estimated coefficient standard errors
    /// Cov         Estimated coefficient covariance matrix
    /// tStats      t statistics of coefficients and p-values
    /// FStat       F statistic and p-value
    /// yMu         Mean of y, adjusted for lags, difference*
    /// ySigma      Standard deviation of y, adjusted for lags, difference*
    /// yHat        Fitted values of y, adjusted for lags, difference*
    /// res         Regression residuals
    /// DWStat      Durbin-Watson statistic
    /// SSR         Regression sum of squares
    /// SSE         Error sum of squares
    /// SST         Total sum of squares
    /// MSE         Mean squared error
    /// RMSE        Standard error of the regression
    /// RSq         R^2 statistic
    /// aRSq        Adjusted R^2 statistic
    /// LL          Loglikelihood of data under Gaussian innovations
    /// AIC         Akaike information criterion
    /// BIC         Bayesian (Schwarz) information criterion
    /// HQC         Hannan-Quinn information criterion
    /// *Lagging and differencing a time series reduce the sample size.
    /// Absent any presample values, if y(t) is defined for t = 1:N, then
    /// the lagged series y(t-k) is defined for t = k+1:N. Differencing
    /// reduces the time base to k+2:N. With p lagged differences, the
    /// common time base is p+2:N and the effective sample size is N-(p+1).
    /// Notes:
    /// o A suitable value for 'lags' must be determined in order to draw valid
    /// inferences from the test. One method is to begin with a maximum lag,
    /// such as the one recommended by Schwert [7], and then test down by
    /// assessing the significance of the coefficient of the largest lagged
    /// change in y, bp. The usual t statistic is appropriate, as reported in
    /// the reg output structure. Another method is to combine a measure of
    /// fit, such as SSR, with information criteria such as AIC, BIC, and
    /// HQC. These statistics are also reported in the reg output structure.
    /// Ng and Perron [6] provide further guidelines.
    /// o The value of 'model' is determined by the growth characteristics of
    /// the time series being tested, and should be chosen with a specific
    /// testing strategy in mind. As discussed in Elder &amp; Kennedy [4],
    /// including too many regressors results in lost power, while including
    /// too few biases the test in favor of the null. In general, if a series
    /// is growing, the 'TS' model provides a reasonable trend-stationary
    /// alternative to a unit-root process with drift. If a series is not
    /// growing, 'AR' and 'ARD' models provide reasonable stationary
    /// alternatives to a unit-root process without drift. The 'ARD'
    /// alternative has mean c/(1-a); the 'AR' alternative has mean 0.
    /// o Dickey-Fuller statistics follow nonstandard distributions under the
    /// null, even asymptotically. Critical values for a range of sample
    /// sizes and significance levels have been tabulated using Monte Carlo
    /// simulations of the null model with Gaussian innovations and five
    /// million replications per sample size. For small samples, values are
    /// valid only for Gaussian innovations; for large samples, values are
    /// also valid for non-Gaussian innovations. Critical values and p-values
    /// are interpolated from the tables. Tables for tests of type 't1' and
    /// 't2' are identical to those for PPTEST.
    /// Example:
    /// Test GDP data for a unit root using a trend-stationary alternative
    /// with 0, 1, and 2 lagged differences:
    /// load Data_GDP
    /// y = log(Data);
    /// h = adftest(y,'model','TS','lags',0:2)
    /// The test fails to reject the unit-root null with each alternative.
    /// References:
    /// [1] Davidson, R. and J. G. MacKinnon. Econometric Theory and Methods.
    /// Oxford, UK: Oxford University Press, 2004.
    /// [2] Dickey, D. A., and W. A. Fuller. "Distribution of the Estimators
    /// for Autoregressive Time Series with a Unit Root." Journal of the
    /// American Statistical Association. Vol. 74, 1979, pp. 427-431.
    /// [3] Dickey, D. A., and W. A. Fuller. "Likelihood Ratio Statistics for
    /// Autoregressive Time Series with a Unit Root." Econometrica. Vol.
    /// 49, 1981, pp. 1057-1072.
    /// [4] Elder, J., and P. E. Kennedy. "Testing for Unit Roots: What Should
    /// Students Be Taught?" Journal of Economic Education. Vol. 32, 2001, 
    /// pp. 137-146.
    /// [5] Hamilton, J. D. Time Series Analysis. Princeton, NJ: Princeton
    /// University Press, 1994.
    /// [6] Ng, S., and P. Perron. "Unit Root Tests in ARMA Models with
    /// Data-Dependent Methods for the Selection of the Truncation Lag."
    /// Journal of the American Statistical Association. Vol. 90, 1995, 
    /// pp. 268-281.
    /// [7] Schwert, W. "Tests for Unit Roots: A Monte Carlo Investigation."
    /// Journal of Business and Economic Statistics. Vol. 7, 1989,
    /// pp. 147-159.
    /// See also PPTEST, LMCTEST, KPSSTEST, VRATIOTEST. 
    /// </remarks>
    /// <param name="y">Input argument #1</param>
    /// <param name="varargin">Array of Objects representing the input arguments 2
    /// through varargin.length+1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object adftest(Object y, params Object[] varargin)
    {
      Object[] argsIn= {y, varargin};

      return mcr.EvaluateFunction("adftest", argsIn);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the adftest MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// ADFTEST Augmented Dickey-Fuller test for a unit root
    /// Syntax:
    /// [h,pValue,stat,cValue,reg] = adftest(y)
    /// [h,pValue,stat,cValue,reg] = adftest(y,param1,val1,param2,val2,...)
    /// Description:
    /// Dickey-Fuller tests assess the null hypothesis of a unit root in a
    /// univariate time series y. All tests use the model
    /// y(t) = c + d*t + a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t),
    /// where L is the lag operator Ly(t) = y(t-1). The null hypothesis
    /// restricts a = 1. Variants of the test, appropriate for series with
    /// different growth characteristics, restrict the drift and deterministic
    /// trend coefficients, c and d, respectively, to be 0. Lagged differences
    /// bk*(1-L)y(t-k), k = 1, ..., p, "augment" the test to account for serial
    /// correlations in the innovations process e(t).
    /// Input Arguments:
    /// y - Vector of time-series data. The last element is the most recent
    /// observation. NaNs indicating missing values are removed.
    /// Optional Input Parameter Name/Value Pairs:
    /// NAME        VALUE
    /// 'lags'      Scalar or vector of nonnegative integers indicating the
    /// number p of lagged changes of y to include in the model.
    /// The default value is 0.
    /// 'model'     String or cell vector of strings indicating the model
    /// variant. Values are 'AR' (autoregressive), 'ARD'
    /// (autoregressive with drift), or 'TS' (trend stationary).
    /// The default value is 'AR'.
    /// o When the value is 'AR', the null model
    /// y(t) = y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)                   
    /// is tested against the alternative model
    /// y(t) = a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)
    /// with AR(1) coefficient a &lt; 1.
    /// o When the value is 'ARD', the null model
    /// y(t) = y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)                   
    /// is tested against the alternative model
    /// y(t) = c + a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)
    /// with drift coefficient c and AR(1) coefficient a &lt; 1.
    /// o When the value is 'TS', the null model
    /// y(t) = c + y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)                   
    /// is tested against the alternative model
    /// y(t) = c + d*t + a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)
    /// with drift coefficient c, deterministic trend coefficient
    /// d, and AR(1) coefficient a &lt; 1. 
    /// 'test'      String or cell vector of strings indicating the type of
    /// test statistic. Values are 't1', 't2', or 'F'. The default
    /// value is 't1'. 
    /// o When the value is 't1', a standard t statistic
    /// t1 = (a-l)/se
    /// is computed from OLS estimates of the AR(1) coefficient a
    /// and its standard error se in the alternative model. The
    /// test assesses the significance of the restriction a = 1.
    /// o When the value is 't2', a lag-adjusted, "unstudentized" t
    /// statistic
    /// t2 = T*(a-1)/(1-b1-...-bp)
    /// is computed from OLS estimates of the AR(1) coefficient a
    /// and the stationary coefficients b1, ..., bp in the
    /// alternative model. T is the effective sample size,
    /// adjusted for lags and missing values. The test assesses
    /// the significance of the restriction a = 1.
    /// o When the value is 'F', an F statistic is computed to
    /// assess the significance of a joint restriction on the
    /// alternative model. If the value of 'model' is 'ARD', the
    /// restriction is a = 1 and c = 0. If the value of 'model'
    /// is 'TS', the restriction is a = 1 and d = 0. An F test is
    /// invalid when the value of 'model' is 'AR'.
    /// 'alpha'     Scalar or vector of nominal significance levels for the
    /// tests. Values must be between 0.001 and 0.999. The default
    /// value is 0.05.
    /// Scalar or single string parameter values are expanded to the length of
    /// any vector value (the number of tests). Vector values must have equal
    /// length. If any value is a row vector, all outputs are row vectors.
    /// Output Arguments:
    /// h - Vector of Boolean decisions for the tests, with length equal to the
    /// number of tests. Values of h equal to 1 indicate rejection of the
    /// unit-root null in favor of the alternative model. Values of h equal
    /// to 0 indicate a failure to reject the unit-root null.
    /// pValue - Vector of p-values of the test statistics, with length equal
    /// to the number of tests. When the value of 'test' is 't1' or 't2',
    /// p-values are left-tail probabilities. When the value of 'test' is
    /// 'F', p-values are right-tail probabilities.
    /// stat - Vector of test statistics, with length equal to the number of
    /// tests. Statistics are computed using OLS estimates of the
    /// coefficients in the alternative model.
    /// cValue - Vector of critical values for the tests, with length equal to
    /// the number of tests. When the value of 'test' is 't1' or 't2',
    /// critical values are for left-tail probabilities. When the value of
    /// 'test' is 'F', critical values are for right-tail probabilities.
    /// reg - Structure of regression statistics from the OLS estimation of 
    /// coefficients in the alternative model. The number of records is
    /// equal to the number of tests. Each record has the following fields:
    /// num         Length of the input series y, with NaNs removed
    /// size        Effective sample size, adjusted for lags, difference*
    /// names       Regression coefficient names			
    /// coeff       Estimated coefficient values
    /// se          Estimated coefficient standard errors
    /// Cov         Estimated coefficient covariance matrix
    /// tStats      t statistics of coefficients and p-values
    /// FStat       F statistic and p-value
    /// yMu         Mean of y, adjusted for lags, difference*
    /// ySigma      Standard deviation of y, adjusted for lags, difference*
    /// yHat        Fitted values of y, adjusted for lags, difference*
    /// res         Regression residuals
    /// DWStat      Durbin-Watson statistic
    /// SSR         Regression sum of squares
    /// SSE         Error sum of squares
    /// SST         Total sum of squares
    /// MSE         Mean squared error
    /// RMSE        Standard error of the regression
    /// RSq         R^2 statistic
    /// aRSq        Adjusted R^2 statistic
    /// LL          Loglikelihood of data under Gaussian innovations
    /// AIC         Akaike information criterion
    /// BIC         Bayesian (Schwarz) information criterion
    /// HQC         Hannan-Quinn information criterion
    /// *Lagging and differencing a time series reduce the sample size.
    /// Absent any presample values, if y(t) is defined for t = 1:N, then
    /// the lagged series y(t-k) is defined for t = k+1:N. Differencing
    /// reduces the time base to k+2:N. With p lagged differences, the
    /// common time base is p+2:N and the effective sample size is N-(p+1).
    /// Notes:
    /// o A suitable value for 'lags' must be determined in order to draw valid
    /// inferences from the test. One method is to begin with a maximum lag,
    /// such as the one recommended by Schwert [7], and then test down by
    /// assessing the significance of the coefficient of the largest lagged
    /// change in y, bp. The usual t statistic is appropriate, as reported in
    /// the reg output structure. Another method is to combine a measure of
    /// fit, such as SSR, with information criteria such as AIC, BIC, and
    /// HQC. These statistics are also reported in the reg output structure.
    /// Ng and Perron [6] provide further guidelines.
    /// o The value of 'model' is determined by the growth characteristics of
    /// the time series being tested, and should be chosen with a specific
    /// testing strategy in mind. As discussed in Elder &amp; Kennedy [4],
    /// including too many regressors results in lost power, while including
    /// too few biases the test in favor of the null. In general, if a series
    /// is growing, the 'TS' model provides a reasonable trend-stationary
    /// alternative to a unit-root process with drift. If a series is not
    /// growing, 'AR' and 'ARD' models provide reasonable stationary
    /// alternatives to a unit-root process without drift. The 'ARD'
    /// alternative has mean c/(1-a); the 'AR' alternative has mean 0.
    /// o Dickey-Fuller statistics follow nonstandard distributions under the
    /// null, even asymptotically. Critical values for a range of sample
    /// sizes and significance levels have been tabulated using Monte Carlo
    /// simulations of the null model with Gaussian innovations and five
    /// million replications per sample size. For small samples, values are
    /// valid only for Gaussian innovations; for large samples, values are
    /// also valid for non-Gaussian innovations. Critical values and p-values
    /// are interpolated from the tables. Tables for tests of type 't1' and
    /// 't2' are identical to those for PPTEST.
    /// Example:
    /// Test GDP data for a unit root using a trend-stationary alternative
    /// with 0, 1, and 2 lagged differences:
    /// load Data_GDP
    /// y = log(Data);
    /// h = adftest(y,'model','TS','lags',0:2)
    /// The test fails to reject the unit-root null with each alternative.
    /// References:
    /// [1] Davidson, R. and J. G. MacKinnon. Econometric Theory and Methods.
    /// Oxford, UK: Oxford University Press, 2004.
    /// [2] Dickey, D. A., and W. A. Fuller. "Distribution of the Estimators
    /// for Autoregressive Time Series with a Unit Root." Journal of the
    /// American Statistical Association. Vol. 74, 1979, pp. 427-431.
    /// [3] Dickey, D. A., and W. A. Fuller. "Likelihood Ratio Statistics for
    /// Autoregressive Time Series with a Unit Root." Econometrica. Vol.
    /// 49, 1981, pp. 1057-1072.
    /// [4] Elder, J., and P. E. Kennedy. "Testing for Unit Roots: What Should
    /// Students Be Taught?" Journal of Economic Education. Vol. 32, 2001, 
    /// pp. 137-146.
    /// [5] Hamilton, J. D. Time Series Analysis. Princeton, NJ: Princeton
    /// University Press, 1994.
    /// [6] Ng, S., and P. Perron. "Unit Root Tests in ARMA Models with
    /// Data-Dependent Methods for the Selection of the Truncation Lag."
    /// Journal of the American Statistical Association. Vol. 90, 1995, 
    /// pp. 268-281.
    /// [7] Schwert, W. "Tests for Unit Roots: A Monte Carlo Investigation."
    /// Journal of Business and Economic Statistics. Vol. 7, 1989,
    /// pp. 147-159.
    /// See also PPTEST, LMCTEST, KPSSTEST, VRATIOTEST. 
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] adftest(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "adftest", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the adftest MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// ADFTEST Augmented Dickey-Fuller test for a unit root
    /// Syntax:
    /// [h,pValue,stat,cValue,reg] = adftest(y)
    /// [h,pValue,stat,cValue,reg] = adftest(y,param1,val1,param2,val2,...)
    /// Description:
    /// Dickey-Fuller tests assess the null hypothesis of a unit root in a
    /// univariate time series y. All tests use the model
    /// y(t) = c + d*t + a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t),
    /// where L is the lag operator Ly(t) = y(t-1). The null hypothesis
    /// restricts a = 1. Variants of the test, appropriate for series with
    /// different growth characteristics, restrict the drift and deterministic
    /// trend coefficients, c and d, respectively, to be 0. Lagged differences
    /// bk*(1-L)y(t-k), k = 1, ..., p, "augment" the test to account for serial
    /// correlations in the innovations process e(t).
    /// Input Arguments:
    /// y - Vector of time-series data. The last element is the most recent
    /// observation. NaNs indicating missing values are removed.
    /// Optional Input Parameter Name/Value Pairs:
    /// NAME        VALUE
    /// 'lags'      Scalar or vector of nonnegative integers indicating the
    /// number p of lagged changes of y to include in the model.
    /// The default value is 0.
    /// 'model'     String or cell vector of strings indicating the model
    /// variant. Values are 'AR' (autoregressive), 'ARD'
    /// (autoregressive with drift), or 'TS' (trend stationary).
    /// The default value is 'AR'.
    /// o When the value is 'AR', the null model
    /// y(t) = y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)                   
    /// is tested against the alternative model
    /// y(t) = a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)
    /// with AR(1) coefficient a &lt; 1.
    /// o When the value is 'ARD', the null model
    /// y(t) = y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)                   
    /// is tested against the alternative model
    /// y(t) = c + a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)
    /// with drift coefficient c and AR(1) coefficient a &lt; 1.
    /// o When the value is 'TS', the null model
    /// y(t) = c + y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)                   
    /// is tested against the alternative model
    /// y(t) = c + d*t + a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)
    /// with drift coefficient c, deterministic trend coefficient
    /// d, and AR(1) coefficient a &lt; 1. 
    /// 'test'      String or cell vector of strings indicating the type of
    /// test statistic. Values are 't1', 't2', or 'F'. The default
    /// value is 't1'. 
    /// o When the value is 't1', a standard t statistic
    /// t1 = (a-l)/se
    /// is computed from OLS estimates of the AR(1) coefficient a
    /// and its standard error se in the alternative model. The
    /// test assesses the significance of the restriction a = 1.
    /// o When the value is 't2', a lag-adjusted, "unstudentized" t
    /// statistic
    /// t2 = T*(a-1)/(1-b1-...-bp)
    /// is computed from OLS estimates of the AR(1) coefficient a
    /// and the stationary coefficients b1, ..., bp in the
    /// alternative model. T is the effective sample size,
    /// adjusted for lags and missing values. The test assesses
    /// the significance of the restriction a = 1.
    /// o When the value is 'F', an F statistic is computed to
    /// assess the significance of a joint restriction on the
    /// alternative model. If the value of 'model' is 'ARD', the
    /// restriction is a = 1 and c = 0. If the value of 'model'
    /// is 'TS', the restriction is a = 1 and d = 0. An F test is
    /// invalid when the value of 'model' is 'AR'.
    /// 'alpha'     Scalar or vector of nominal significance levels for the
    /// tests. Values must be between 0.001 and 0.999. The default
    /// value is 0.05.
    /// Scalar or single string parameter values are expanded to the length of
    /// any vector value (the number of tests). Vector values must have equal
    /// length. If any value is a row vector, all outputs are row vectors.
    /// Output Arguments:
    /// h - Vector of Boolean decisions for the tests, with length equal to the
    /// number of tests. Values of h equal to 1 indicate rejection of the
    /// unit-root null in favor of the alternative model. Values of h equal
    /// to 0 indicate a failure to reject the unit-root null.
    /// pValue - Vector of p-values of the test statistics, with length equal
    /// to the number of tests. When the value of 'test' is 't1' or 't2',
    /// p-values are left-tail probabilities. When the value of 'test' is
    /// 'F', p-values are right-tail probabilities.
    /// stat - Vector of test statistics, with length equal to the number of
    /// tests. Statistics are computed using OLS estimates of the
    /// coefficients in the alternative model.
    /// cValue - Vector of critical values for the tests, with length equal to
    /// the number of tests. When the value of 'test' is 't1' or 't2',
    /// critical values are for left-tail probabilities. When the value of
    /// 'test' is 'F', critical values are for right-tail probabilities.
    /// reg - Structure of regression statistics from the OLS estimation of 
    /// coefficients in the alternative model. The number of records is
    /// equal to the number of tests. Each record has the following fields:
    /// num         Length of the input series y, with NaNs removed
    /// size        Effective sample size, adjusted for lags, difference*
    /// names       Regression coefficient names			
    /// coeff       Estimated coefficient values
    /// se          Estimated coefficient standard errors
    /// Cov         Estimated coefficient covariance matrix
    /// tStats      t statistics of coefficients and p-values
    /// FStat       F statistic and p-value
    /// yMu         Mean of y, adjusted for lags, difference*
    /// ySigma      Standard deviation of y, adjusted for lags, difference*
    /// yHat        Fitted values of y, adjusted for lags, difference*
    /// res         Regression residuals
    /// DWStat      Durbin-Watson statistic
    /// SSR         Regression sum of squares
    /// SSE         Error sum of squares
    /// SST         Total sum of squares
    /// MSE         Mean squared error
    /// RMSE        Standard error of the regression
    /// RSq         R^2 statistic
    /// aRSq        Adjusted R^2 statistic
    /// LL          Loglikelihood of data under Gaussian innovations
    /// AIC         Akaike information criterion
    /// BIC         Bayesian (Schwarz) information criterion
    /// HQC         Hannan-Quinn information criterion
    /// *Lagging and differencing a time series reduce the sample size.
    /// Absent any presample values, if y(t) is defined for t = 1:N, then
    /// the lagged series y(t-k) is defined for t = k+1:N. Differencing
    /// reduces the time base to k+2:N. With p lagged differences, the
    /// common time base is p+2:N and the effective sample size is N-(p+1).
    /// Notes:
    /// o A suitable value for 'lags' must be determined in order to draw valid
    /// inferences from the test. One method is to begin with a maximum lag,
    /// such as the one recommended by Schwert [7], and then test down by
    /// assessing the significance of the coefficient of the largest lagged
    /// change in y, bp. The usual t statistic is appropriate, as reported in
    /// the reg output structure. Another method is to combine a measure of
    /// fit, such as SSR, with information criteria such as AIC, BIC, and
    /// HQC. These statistics are also reported in the reg output structure.
    /// Ng and Perron [6] provide further guidelines.
    /// o The value of 'model' is determined by the growth characteristics of
    /// the time series being tested, and should be chosen with a specific
    /// testing strategy in mind. As discussed in Elder &amp; Kennedy [4],
    /// including too many regressors results in lost power, while including
    /// too few biases the test in favor of the null. In general, if a series
    /// is growing, the 'TS' model provides a reasonable trend-stationary
    /// alternative to a unit-root process with drift. If a series is not
    /// growing, 'AR' and 'ARD' models provide reasonable stationary
    /// alternatives to a unit-root process without drift. The 'ARD'
    /// alternative has mean c/(1-a); the 'AR' alternative has mean 0.
    /// o Dickey-Fuller statistics follow nonstandard distributions under the
    /// null, even asymptotically. Critical values for a range of sample
    /// sizes and significance levels have been tabulated using Monte Carlo
    /// simulations of the null model with Gaussian innovations and five
    /// million replications per sample size. For small samples, values are
    /// valid only for Gaussian innovations; for large samples, values are
    /// also valid for non-Gaussian innovations. Critical values and p-values
    /// are interpolated from the tables. Tables for tests of type 't1' and
    /// 't2' are identical to those for PPTEST.
    /// Example:
    /// Test GDP data for a unit root using a trend-stationary alternative
    /// with 0, 1, and 2 lagged differences:
    /// load Data_GDP
    /// y = log(Data);
    /// h = adftest(y,'model','TS','lags',0:2)
    /// The test fails to reject the unit-root null with each alternative.
    /// References:
    /// [1] Davidson, R. and J. G. MacKinnon. Econometric Theory and Methods.
    /// Oxford, UK: Oxford University Press, 2004.
    /// [2] Dickey, D. A., and W. A. Fuller. "Distribution of the Estimators
    /// for Autoregressive Time Series with a Unit Root." Journal of the
    /// American Statistical Association. Vol. 74, 1979, pp. 427-431.
    /// [3] Dickey, D. A., and W. A. Fuller. "Likelihood Ratio Statistics for
    /// Autoregressive Time Series with a Unit Root." Econometrica. Vol.
    /// 49, 1981, pp. 1057-1072.
    /// [4] Elder, J., and P. E. Kennedy. "Testing for Unit Roots: What Should
    /// Students Be Taught?" Journal of Economic Education. Vol. 32, 2001, 
    /// pp. 137-146.
    /// [5] Hamilton, J. D. Time Series Analysis. Princeton, NJ: Princeton
    /// University Press, 1994.
    /// [6] Ng, S., and P. Perron. "Unit Root Tests in ARMA Models with
    /// Data-Dependent Methods for the Selection of the Truncation Lag."
    /// Journal of the American Statistical Association. Vol. 90, 1995, 
    /// pp. 268-281.
    /// [7] Schwert, W. "Tests for Unit Roots: A Monte Carlo Investigation."
    /// Journal of Business and Economic Statistics. Vol. 7, 1989,
    /// pp. 147-159.
    /// See also PPTEST, LMCTEST, KPSSTEST, VRATIOTEST. 
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="y">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] adftest(int numArgsOut, Object y)
    {
      return mcr.EvaluateFunction(numArgsOut, "adftest", y);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the adftest MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// ADFTEST Augmented Dickey-Fuller test for a unit root
    /// Syntax:
    /// [h,pValue,stat,cValue,reg] = adftest(y)
    /// [h,pValue,stat,cValue,reg] = adftest(y,param1,val1,param2,val2,...)
    /// Description:
    /// Dickey-Fuller tests assess the null hypothesis of a unit root in a
    /// univariate time series y. All tests use the model
    /// y(t) = c + d*t + a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t),
    /// where L is the lag operator Ly(t) = y(t-1). The null hypothesis
    /// restricts a = 1. Variants of the test, appropriate for series with
    /// different growth characteristics, restrict the drift and deterministic
    /// trend coefficients, c and d, respectively, to be 0. Lagged differences
    /// bk*(1-L)y(t-k), k = 1, ..., p, "augment" the test to account for serial
    /// correlations in the innovations process e(t).
    /// Input Arguments:
    /// y - Vector of time-series data. The last element is the most recent
    /// observation. NaNs indicating missing values are removed.
    /// Optional Input Parameter Name/Value Pairs:
    /// NAME        VALUE
    /// 'lags'      Scalar or vector of nonnegative integers indicating the
    /// number p of lagged changes of y to include in the model.
    /// The default value is 0.
    /// 'model'     String or cell vector of strings indicating the model
    /// variant. Values are 'AR' (autoregressive), 'ARD'
    /// (autoregressive with drift), or 'TS' (trend stationary).
    /// The default value is 'AR'.
    /// o When the value is 'AR', the null model
    /// y(t) = y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)                   
    /// is tested against the alternative model
    /// y(t) = a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)
    /// with AR(1) coefficient a &lt; 1.
    /// o When the value is 'ARD', the null model
    /// y(t) = y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)                   
    /// is tested against the alternative model
    /// y(t) = c + a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)
    /// with drift coefficient c and AR(1) coefficient a &lt; 1.
    /// o When the value is 'TS', the null model
    /// y(t) = c + y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)                   
    /// is tested against the alternative model
    /// y(t) = c + d*t + a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)
    /// with drift coefficient c, deterministic trend coefficient
    /// d, and AR(1) coefficient a &lt; 1. 
    /// 'test'      String or cell vector of strings indicating the type of
    /// test statistic. Values are 't1', 't2', or 'F'. The default
    /// value is 't1'. 
    /// o When the value is 't1', a standard t statistic
    /// t1 = (a-l)/se
    /// is computed from OLS estimates of the AR(1) coefficient a
    /// and its standard error se in the alternative model. The
    /// test assesses the significance of the restriction a = 1.
    /// o When the value is 't2', a lag-adjusted, "unstudentized" t
    /// statistic
    /// t2 = T*(a-1)/(1-b1-...-bp)
    /// is computed from OLS estimates of the AR(1) coefficient a
    /// and the stationary coefficients b1, ..., bp in the
    /// alternative model. T is the effective sample size,
    /// adjusted for lags and missing values. The test assesses
    /// the significance of the restriction a = 1.
    /// o When the value is 'F', an F statistic is computed to
    /// assess the significance of a joint restriction on the
    /// alternative model. If the value of 'model' is 'ARD', the
    /// restriction is a = 1 and c = 0. If the value of 'model'
    /// is 'TS', the restriction is a = 1 and d = 0. An F test is
    /// invalid when the value of 'model' is 'AR'.
    /// 'alpha'     Scalar or vector of nominal significance levels for the
    /// tests. Values must be between 0.001 and 0.999. The default
    /// value is 0.05.
    /// Scalar or single string parameter values are expanded to the length of
    /// any vector value (the number of tests). Vector values must have equal
    /// length. If any value is a row vector, all outputs are row vectors.
    /// Output Arguments:
    /// h - Vector of Boolean decisions for the tests, with length equal to the
    /// number of tests. Values of h equal to 1 indicate rejection of the
    /// unit-root null in favor of the alternative model. Values of h equal
    /// to 0 indicate a failure to reject the unit-root null.
    /// pValue - Vector of p-values of the test statistics, with length equal
    /// to the number of tests. When the value of 'test' is 't1' or 't2',
    /// p-values are left-tail probabilities. When the value of 'test' is
    /// 'F', p-values are right-tail probabilities.
    /// stat - Vector of test statistics, with length equal to the number of
    /// tests. Statistics are computed using OLS estimates of the
    /// coefficients in the alternative model.
    /// cValue - Vector of critical values for the tests, with length equal to
    /// the number of tests. When the value of 'test' is 't1' or 't2',
    /// critical values are for left-tail probabilities. When the value of
    /// 'test' is 'F', critical values are for right-tail probabilities.
    /// reg - Structure of regression statistics from the OLS estimation of 
    /// coefficients in the alternative model. The number of records is
    /// equal to the number of tests. Each record has the following fields:
    /// num         Length of the input series y, with NaNs removed
    /// size        Effective sample size, adjusted for lags, difference*
    /// names       Regression coefficient names			
    /// coeff       Estimated coefficient values
    /// se          Estimated coefficient standard errors
    /// Cov         Estimated coefficient covariance matrix
    /// tStats      t statistics of coefficients and p-values
    /// FStat       F statistic and p-value
    /// yMu         Mean of y, adjusted for lags, difference*
    /// ySigma      Standard deviation of y, adjusted for lags, difference*
    /// yHat        Fitted values of y, adjusted for lags, difference*
    /// res         Regression residuals
    /// DWStat      Durbin-Watson statistic
    /// SSR         Regression sum of squares
    /// SSE         Error sum of squares
    /// SST         Total sum of squares
    /// MSE         Mean squared error
    /// RMSE        Standard error of the regression
    /// RSq         R^2 statistic
    /// aRSq        Adjusted R^2 statistic
    /// LL          Loglikelihood of data under Gaussian innovations
    /// AIC         Akaike information criterion
    /// BIC         Bayesian (Schwarz) information criterion
    /// HQC         Hannan-Quinn information criterion
    /// *Lagging and differencing a time series reduce the sample size.
    /// Absent any presample values, if y(t) is defined for t = 1:N, then
    /// the lagged series y(t-k) is defined for t = k+1:N. Differencing
    /// reduces the time base to k+2:N. With p lagged differences, the
    /// common time base is p+2:N and the effective sample size is N-(p+1).
    /// Notes:
    /// o A suitable value for 'lags' must be determined in order to draw valid
    /// inferences from the test. One method is to begin with a maximum lag,
    /// such as the one recommended by Schwert [7], and then test down by
    /// assessing the significance of the coefficient of the largest lagged
    /// change in y, bp. The usual t statistic is appropriate, as reported in
    /// the reg output structure. Another method is to combine a measure of
    /// fit, such as SSR, with information criteria such as AIC, BIC, and
    /// HQC. These statistics are also reported in the reg output structure.
    /// Ng and Perron [6] provide further guidelines.
    /// o The value of 'model' is determined by the growth characteristics of
    /// the time series being tested, and should be chosen with a specific
    /// testing strategy in mind. As discussed in Elder &amp; Kennedy [4],
    /// including too many regressors results in lost power, while including
    /// too few biases the test in favor of the null. In general, if a series
    /// is growing, the 'TS' model provides a reasonable trend-stationary
    /// alternative to a unit-root process with drift. If a series is not
    /// growing, 'AR' and 'ARD' models provide reasonable stationary
    /// alternatives to a unit-root process without drift. The 'ARD'
    /// alternative has mean c/(1-a); the 'AR' alternative has mean 0.
    /// o Dickey-Fuller statistics follow nonstandard distributions under the
    /// null, even asymptotically. Critical values for a range of sample
    /// sizes and significance levels have been tabulated using Monte Carlo
    /// simulations of the null model with Gaussian innovations and five
    /// million replications per sample size. For small samples, values are
    /// valid only for Gaussian innovations; for large samples, values are
    /// also valid for non-Gaussian innovations. Critical values and p-values
    /// are interpolated from the tables. Tables for tests of type 't1' and
    /// 't2' are identical to those for PPTEST.
    /// Example:
    /// Test GDP data for a unit root using a trend-stationary alternative
    /// with 0, 1, and 2 lagged differences:
    /// load Data_GDP
    /// y = log(Data);
    /// h = adftest(y,'model','TS','lags',0:2)
    /// The test fails to reject the unit-root null with each alternative.
    /// References:
    /// [1] Davidson, R. and J. G. MacKinnon. Econometric Theory and Methods.
    /// Oxford, UK: Oxford University Press, 2004.
    /// [2] Dickey, D. A., and W. A. Fuller. "Distribution of the Estimators
    /// for Autoregressive Time Series with a Unit Root." Journal of the
    /// American Statistical Association. Vol. 74, 1979, pp. 427-431.
    /// [3] Dickey, D. A., and W. A. Fuller. "Likelihood Ratio Statistics for
    /// Autoregressive Time Series with a Unit Root." Econometrica. Vol.
    /// 49, 1981, pp. 1057-1072.
    /// [4] Elder, J., and P. E. Kennedy. "Testing for Unit Roots: What Should
    /// Students Be Taught?" Journal of Economic Education. Vol. 32, 2001, 
    /// pp. 137-146.
    /// [5] Hamilton, J. D. Time Series Analysis. Princeton, NJ: Princeton
    /// University Press, 1994.
    /// [6] Ng, S., and P. Perron. "Unit Root Tests in ARMA Models with
    /// Data-Dependent Methods for the Selection of the Truncation Lag."
    /// Journal of the American Statistical Association. Vol. 90, 1995, 
    /// pp. 268-281.
    /// [7] Schwert, W. "Tests for Unit Roots: A Monte Carlo Investigation."
    /// Journal of Business and Economic Statistics. Vol. 7, 1989,
    /// pp. 147-159.
    /// See also PPTEST, LMCTEST, KPSSTEST, VRATIOTEST. 
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="y">Input argument #1</param>
    /// <param name="varargin">Array of Objects representing the input arguments 2
    /// through varargin.length+1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] adftest(int numArgsOut, Object y, params Object[] varargin)
    {
      Object[] argsIn= {y, varargin};

      return mcr.EvaluateFunction(numArgsOut, "adftest", argsIn);
    }


    /// <summary>
    /// Provides an interface for the adftest function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// ADFTEST Augmented Dickey-Fuller test for a unit root
    /// Syntax:
    /// [h,pValue,stat,cValue,reg] = adftest(y)
    /// [h,pValue,stat,cValue,reg] = adftest(y,param1,val1,param2,val2,...)
    /// Description:
    /// Dickey-Fuller tests assess the null hypothesis of a unit root in a
    /// univariate time series y. All tests use the model
    /// y(t) = c + d*t + a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t),
    /// where L is the lag operator Ly(t) = y(t-1). The null hypothesis
    /// restricts a = 1. Variants of the test, appropriate for series with
    /// different growth characteristics, restrict the drift and deterministic
    /// trend coefficients, c and d, respectively, to be 0. Lagged differences
    /// bk*(1-L)y(t-k), k = 1, ..., p, "augment" the test to account for serial
    /// correlations in the innovations process e(t).
    /// Input Arguments:
    /// y - Vector of time-series data. The last element is the most recent
    /// observation. NaNs indicating missing values are removed.
    /// Optional Input Parameter Name/Value Pairs:
    /// NAME        VALUE
    /// 'lags'      Scalar or vector of nonnegative integers indicating the
    /// number p of lagged changes of y to include in the model.
    /// The default value is 0.
    /// 'model'     String or cell vector of strings indicating the model
    /// variant. Values are 'AR' (autoregressive), 'ARD'
    /// (autoregressive with drift), or 'TS' (trend stationary).
    /// The default value is 'AR'.
    /// o When the value is 'AR', the null model
    /// y(t) = y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)                   
    /// is tested against the alternative model
    /// y(t) = a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)
    /// with AR(1) coefficient a &lt; 1.
    /// o When the value is 'ARD', the null model
    /// y(t) = y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)                   
    /// is tested against the alternative model
    /// y(t) = c + a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)
    /// with drift coefficient c and AR(1) coefficient a &lt; 1.
    /// o When the value is 'TS', the null model
    /// y(t) = c + y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)                   
    /// is tested against the alternative model
    /// y(t) = c + d*t + a*y(t-1) + b1*(1-L)y(t-1)
    /// + b2*(1-L)y(t-2)
    /// + ... 
    /// + bp*(1-L)y(t-p)
    /// + e(t)
    /// with drift coefficient c, deterministic trend coefficient
    /// d, and AR(1) coefficient a &lt; 1. 
    /// 'test'      String or cell vector of strings indicating the type of
    /// test statistic. Values are 't1', 't2', or 'F'. The default
    /// value is 't1'. 
    /// o When the value is 't1', a standard t statistic
    /// t1 = (a-l)/se
    /// is computed from OLS estimates of the AR(1) coefficient a
    /// and its standard error se in the alternative model. The
    /// test assesses the significance of the restriction a = 1.
    /// o When the value is 't2', a lag-adjusted, "unstudentized" t
    /// statistic
    /// t2 = T*(a-1)/(1-b1-...-bp)
    /// is computed from OLS estimates of the AR(1) coefficient a
    /// and the stationary coefficients b1, ..., bp in the
    /// alternative model. T is the effective sample size,
    /// adjusted for lags and missing values. The test assesses
    /// the significance of the restriction a = 1.
    /// o When the value is 'F', an F statistic is computed to
    /// assess the significance of a joint restriction on the
    /// alternative model. If the value of 'model' is 'ARD', the
    /// restriction is a = 1 and c = 0. If the value of 'model'
    /// is 'TS', the restriction is a = 1 and d = 0. An F test is
    /// invalid when the value of 'model' is 'AR'.
    /// 'alpha'     Scalar or vector of nominal significance levels for the
    /// tests. Values must be between 0.001 and 0.999. The default
    /// value is 0.05.
    /// Scalar or single string parameter values are expanded to the length of
    /// any vector value (the number of tests). Vector values must have equal
    /// length. If any value is a row vector, all outputs are row vectors.
    /// Output Arguments:
    /// h - Vector of Boolean decisions for the tests, with length equal to the
    /// number of tests. Values of h equal to 1 indicate rejection of the
    /// unit-root null in favor of the alternative model. Values of h equal
    /// to 0 indicate a failure to reject the unit-root null.
    /// pValue - Vector of p-values of the test statistics, with length equal
    /// to the number of tests. When the value of 'test' is 't1' or 't2',
    /// p-values are left-tail probabilities. When the value of 'test' is
    /// 'F', p-values are right-tail probabilities.
    /// stat - Vector of test statistics, with length equal to the number of
    /// tests. Statistics are computed using OLS estimates of the
    /// coefficients in the alternative model.
    /// cValue - Vector of critical values for the tests, with length equal to
    /// the number of tests. When the value of 'test' is 't1' or 't2',
    /// critical values are for left-tail probabilities. When the value of
    /// 'test' is 'F', critical values are for right-tail probabilities.
    /// reg - Structure of regression statistics from the OLS estimation of 
    /// coefficients in the alternative model. The number of records is
    /// equal to the number of tests. Each record has the following fields:
    /// num         Length of the input series y, with NaNs removed
    /// size        Effective sample size, adjusted for lags, difference*
    /// names       Regression coefficient names			
    /// coeff       Estimated coefficient values
    /// se          Estimated coefficient standard errors
    /// Cov         Estimated coefficient covariance matrix
    /// tStats      t statistics of coefficients and p-values
    /// FStat       F statistic and p-value
    /// yMu         Mean of y, adjusted for lags, difference*
    /// ySigma      Standard deviation of y, adjusted for lags, difference*
    /// yHat        Fitted values of y, adjusted for lags, difference*
    /// res         Regression residuals
    /// DWStat      Durbin-Watson statistic
    /// SSR         Regression sum of squares
    /// SSE         Error sum of squares
    /// SST         Total sum of squares
    /// MSE         Mean squared error
    /// RMSE        Standard error of the regression
    /// RSq         R^2 statistic
    /// aRSq        Adjusted R^2 statistic
    /// LL          Loglikelihood of data under Gaussian innovations
    /// AIC         Akaike information criterion
    /// BIC         Bayesian (Schwarz) information criterion
    /// HQC         Hannan-Quinn information criterion
    /// *Lagging and differencing a time series reduce the sample size.
    /// Absent any presample values, if y(t) is defined for t = 1:N, then
    /// the lagged series y(t-k) is defined for t = k+1:N. Differencing
    /// reduces the time base to k+2:N. With p lagged differences, the
    /// common time base is p+2:N and the effective sample size is N-(p+1).
    /// Notes:
    /// o A suitable value for 'lags' must be determined in order to draw valid
    /// inferences from the test. One method is to begin with a maximum lag,
    /// such as the one recommended by Schwert [7], and then test down by
    /// assessing the significance of the coefficient of the largest lagged
    /// change in y, bp. The usual t statistic is appropriate, as reported in
    /// the reg output structure. Another method is to combine a measure of
    /// fit, such as SSR, with information criteria such as AIC, BIC, and
    /// HQC. These statistics are also reported in the reg output structure.
    /// Ng and Perron [6] provide further guidelines.
    /// o The value of 'model' is determined by the growth characteristics of
    /// the time series being tested, and should be chosen with a specific
    /// testing strategy in mind. As discussed in Elder &amp; Kennedy [4],
    /// including too many regressors results in lost power, while including
    /// too few biases the test in favor of the null. In general, if a series
    /// is growing, the 'TS' model provides a reasonable trend-stationary
    /// alternative to a unit-root process with drift. If a series is not
    /// growing, 'AR' and 'ARD' models provide reasonable stationary
    /// alternatives to a unit-root process without drift. The 'ARD'
    /// alternative has mean c/(1-a); the 'AR' alternative has mean 0.
    /// o Dickey-Fuller statistics follow nonstandard distributions under the
    /// null, even asymptotically. Critical values for a range of sample
    /// sizes and significance levels have been tabulated using Monte Carlo
    /// simulations of the null model with Gaussian innovations and five
    /// million replications per sample size. For small samples, values are
    /// valid only for Gaussian innovations; for large samples, values are
    /// also valid for non-Gaussian innovations. Critical values and p-values
    /// are interpolated from the tables. Tables for tests of type 't1' and
    /// 't2' are identical to those for PPTEST.
    /// Example:
    /// Test GDP data for a unit root using a trend-stationary alternative
    /// with 0, 1, and 2 lagged differences:
    /// load Data_GDP
    /// y = log(Data);
    /// h = adftest(y,'model','TS','lags',0:2)
    /// The test fails to reject the unit-root null with each alternative.
    /// References:
    /// [1] Davidson, R. and J. G. MacKinnon. Econometric Theory and Methods.
    /// Oxford, UK: Oxford University Press, 2004.
    /// [2] Dickey, D. A., and W. A. Fuller. "Distribution of the Estimators
    /// for Autoregressive Time Series with a Unit Root." Journal of the
    /// American Statistical Association. Vol. 74, 1979, pp. 427-431.
    /// [3] Dickey, D. A., and W. A. Fuller. "Likelihood Ratio Statistics for
    /// Autoregressive Time Series with a Unit Root." Econometrica. Vol.
    /// 49, 1981, pp. 1057-1072.
    /// [4] Elder, J., and P. E. Kennedy. "Testing for Unit Roots: What Should
    /// Students Be Taught?" Journal of Economic Education. Vol. 32, 2001, 
    /// pp. 137-146.
    /// [5] Hamilton, J. D. Time Series Analysis. Princeton, NJ: Princeton
    /// University Press, 1994.
    /// [6] Ng, S., and P. Perron. "Unit Root Tests in ARMA Models with
    /// Data-Dependent Methods for the Selection of the Truncation Lag."
    /// Journal of the American Statistical Association. Vol. 90, 1995, 
    /// pp. 268-281.
    /// [7] Schwert, W. "Tests for Unit Roots: A Monte Carlo Investigation."
    /// Journal of Business and Economic Statistics. Vol. 7, 1989,
    /// pp. 147-159.
    /// See also PPTEST, LMCTEST, KPSSTEST, VRATIOTEST. 
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("adftest", 1, 5, 1)]
    protected void adftest(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("adftest", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }

    /// <summary>
    /// This method will cause a MATLAB figure window to behave as a modal dialog box.
    /// The method will not return until all the figure windows associated with this
    /// component have been closed.
    /// </summary>
    /// <remarks>
    /// An application should only call this method when required to keep the
    /// MATLAB figure window from disappearing.  Other techniques, such as calling
    /// Console.ReadLine() from the application should be considered where
    /// possible.</remarks>
    ///
    public void WaitForFiguresToDie()
    {
      mcr.WaitForFiguresToDie();
    }



    #endregion Methods

    #region Class Members

    private static MWMCR mcr= null;

    private static Exception ex_= null;

    private bool disposed= false;

    #endregion Class Members
  }
}
